using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public float tilt;
    public float fireRate;
    public Boundary boundary;
    public GameObject bolt;
    public Transform shotSpawn;

    private float nextFire = 0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.velocity = movement * speed;

        rb.position = boundary.Clamp(rb.position);

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }
}