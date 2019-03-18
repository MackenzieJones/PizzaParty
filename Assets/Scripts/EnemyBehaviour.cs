using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * 0.03f);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, 1.1f, 0)));
    }
}
