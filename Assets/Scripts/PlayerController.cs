using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementPower = 15f;

    [SerializeField]
    private float jumpPower = 20f;

    private float powerMultiplyer = 20f;

    private Rigidbody rigidBody;
    private bool isGrounded => rigidBody.velocity.y < 0.1 && rigidBody.velocity.y > -0.1;

    private bool shouldJump = false;
    private Vector3 movementVector = Vector3.zero;

    //public interface handeler from GameManager
    public ICollectionHandler collectionHandeler;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        movementPower *= powerMultiplyer;
        jumpPower *= powerMultiplyer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneNames.Level1);
        }

        float horizontalInput = Input.GetAxis(InputStrings.Horizontal);

        float verticalInput = Input.GetAxis(InputStrings.Vertical);

        movementVector = new Vector3(horizontalInput, 0 , verticalInput);


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            shouldJump = true;
        } 

    }


    private void FixedUpdate()
    {
        // drugi naèin kretanja igraèa
        /*
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(Vector3.forward * movementPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(Vector3.back * movementPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(Vector3.left * movementPower * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(Vector3.right * movementPower * Time.deltaTime);
        }*/

        rigidBody.AddForce(movementVector * Time.deltaTime * movementPower);

        if (shouldJump)
        {
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            shouldJump = false;
        }
    }

    //interaction with objects if they are not triggered
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Collectable))
        {
            Destroy(collision.gameObject);
        }
    }*/

    //interaction with objects if they are  triggered

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Collectable))
        {
            //Destroy(other.gameObject);
            collectionHandeler.PlayerDidCollectItem(other.gameObject);
        }
    }
}

public struct InputStrings
{
    public static string Horizontal = "Horizontal";
    public static string Vertical = "Vertical";

}

public struct Tags
{
    public static string Collectable = "Collectable";
}

public struct SceneNames
{
    public static string Level1 = "Level1";
    public static string StartScene = "StartScene";
}

