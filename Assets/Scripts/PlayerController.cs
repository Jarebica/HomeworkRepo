using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;

    [SerializeField]
    private float jumpPower = 20f;

    private Rigidbody rigidBody;

    private bool isGrounded => rigidBody.velocity.y < 0.1 && rigidBody.velocity.y > -0.1;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    private void Update()
    {

        //Jedan naèin za kretanje igraèa
        /*
        var movementVector =Vector3.zero;  
        if (Input.GetKey(KeyCode.W))
        {
            movementVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementVector += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementVector += Vector3.right;
        }

        movementVector.Normalize();
        movementVector *= speed;

        transform.position += movementVector * Time.deltaTime;
        */

    }


    private void FixedUpdate()
    {
        // drugi naèin kretanja igraèa

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}


