using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(3000, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
