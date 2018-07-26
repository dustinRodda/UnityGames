using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public int speed;
    public Rigidbody rb;

    private void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}
