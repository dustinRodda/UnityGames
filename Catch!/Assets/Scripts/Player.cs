using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public Transform playerCamera;
    public Transform ballTransform;
    private Rigidbody ball;
    private bool isHoldingBall;
    private float throwAngle;
    private bool isAngleSet;
    private float throwForce;
    private bool isForceSet;
    private float catchDistance;
	// Use this for initialization
	void Start ()
    {
        if(!isLocalPlayer)
        {
            playerCamera.gameObject.SetActive(false);
        }
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
        isHoldingBall = true;
        throwAngle = 0f;
        throwForce = 0f;
        catchDistance = 1.2f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isHoldingBall)
        {
            SetThrowAngle();
            SetThrowForce();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isHoldingBall)
            {
                ThrowBall();
                Debug.Log("Throwing");
            }
            else
            {
                isHoldingBall = CatchBall();
                Debug.Log("Catching");
            }
        }
		
	}

    void ThrowBall()
    {
        if(isAngleSet && isForceSet)
        {
            ball.useGravity = true;
            ball.rotation = Quaternion.Euler(-throwAngle, 0, 0);
            ball.AddRelativeForce(new Vector3(0, 0, throwForce), ForceMode.Force);
            throwAngle = 0f;
            throwForce = 0f;
            isHoldingBall = false;
        }
    }

    void SetThrowAngle()
    {
        if(Input.GetMouseButton(0))
        {
            throwAngle = Mathf.MoveTowardsAngle(throwAngle, 90f, 45 * Time.deltaTime);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Throw Angle = " + throwAngle);
            isAngleSet = true;
        }
    }
    void SetThrowForce()
    {
        if (Input.GetMouseButton(1))
        {
            throwForce = Mathf.MoveTowards(throwForce, 1000, 500 * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Throw Force = " + throwForce);
            isForceSet = true;
        }
        
    }

    bool CatchBall()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, playerCamera.forward, out hit, catchDistance))
        {
            if(hit.transform.CompareTag("Ball"))
            {
                ball = hit.transform.GetComponent<Rigidbody>();
                ball.useGravity = false;
                ball.position = ballTransform.position;
                ball.rotation = ballTransform.rotation;
                return true;
            }
        }
        return false;
    }
}
