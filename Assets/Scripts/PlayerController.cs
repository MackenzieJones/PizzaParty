using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private Rigidbody rb;
    public float speed;
    private float xMove;
    private float zMove;
    private bool grounded;
    private float shootTimer;
    public GameObject pizza;
    public AudioSource brandonPizza;
    private float oldMouseX;
    public float mouseSensitivity = 0.001f;
    public float clampAngle = 80.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        xMove = 0;
        zMove = 0;
        speed = 0.2f;
        grounded = false;
        shootTimer = 0;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey("w")) {
            xMove = -1;
        } else if (Input.GetKey("s")) {
            xMove = 1;
        } else {
            xMove = 0;
        }
        if (Input.GetKey("a")){
            zMove = 1;
        }else if (Input.GetKey("d")){
            zMove = -1;
        }else{
            zMove = 0;
        }

        if (transform.position.y < 1.5f){
            grounded = true;
        } else {
            grounded = false;
        }

        if (Input.GetKeyDown("space") && grounded)
            rb.AddForce(transform.up * 1000);

        if (Input.GetMouseButtonDown(0) && shootTimer < 1){
            shootPizza();
            shootTimer = 15;
            brandonPizza.Play();
        }

    }

    private void shootPizza()
    {
        GameObject newPizza = Instantiate(pizza, transform.position + new Vector3(0, 2, 0), rb.rotation * Quaternion.Euler(0, 90, 0));
    }

    void FixedUpdate(){

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        if (shootTimer > 0){
            shootTimer -= 1;
        }
        rb.MovePosition(transform.position + (transform.forward * xMove * speed) + (transform.right * zMove * speed));

    }
}
