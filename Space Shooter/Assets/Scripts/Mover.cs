using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public int speed;
    public Rigidbody rb;
    public Boundary boundary;
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.velocity = transform.forward * speed;
        if(boundary.OutOfBounds(transform.position))
        {
            Destroy(gameObject);
        }
	}
}
