using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 18f;
    public float jumpHeight = 25f;
    public float turnSpeed = 20f;

    public float velocity = 5f;
    Vector3 input;
    Vector3 playerMovement;
    float angle;

    Quaternion targetRotation;

    //private int jumpCount = 0;
    private bool isOnGround = true;
    private const int MAX_JUMP = 2;
    private int currentJump = 0;

    private Rigidbody rb;

    //public CharacterController _controller;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float hAxis = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float vAxis = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        if (Input.GetKey("w"))
        {
            Debug.Log("W clicked");
        }
        if (Input.GetKey("a"))
        {
            Debug.Log("A clicked");
        }
        if (Input.GetKey("s"))
        {
            Debug.Log("s clicked");
        }
        if (Input.GetKey("d"))
        {
            Debug.Log("D clicked");
        }
        Debug.Log(isOnGround);

        GetInput();
        //float hAxis = input.x * Time.deltaTime * speed;
        //float vAxis = input.y * Time.deltaTime * speed;

        Move();
        // Vector3 playerMovement = new Vector3(hAxis, 0f, vAxis);
        //Debug.Log(playerMovement);

        if(Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;


        //CalculateDirection();
        //Rotate();

        //rb.MovePosition(transform.position + playerMovement);
        //rb.MovePosition(transform.position + playerMovement);
        //transform.Translate(playerMovement, Space.Self);

        //if (Input.GetKeyDown("space") && ((isOnGround == true) || MAX_JUMP > currentJump))
        //{
        //    Debug.Log("Jumping");
        //    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Jump_Sound");
        //    isOnGround = false;
        //    //rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        //    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //    currentJump++;
        //}
        Jumping();
        Attacking();
        //if(Input.GetKeyDown("l"))
        //{
        //    Debug.Log("Attack");
        //}

    }

    void Attacking()
    {
        if (Input.GetKeyDown("l"))
        {
            Debug.Log("Attack");
        }
    }

    void Jumping()
    {
        if(Input.GetKeyDown("space") && ((isOnGround == true) || MAX_JUMP > currentJump))
        {
            Debug.Log("Jumping");
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Jump_Sound");
            isOnGround = false;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            currentJump++;
        }
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        input.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        //angle += cam.eulerAngles.y;
    }
    
    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move()
    {
        playerMovement = new Vector3(input.x , 0f, input.y);
        //Debug.Log(playerMovement);
        //transform.Translate(transform.forward * velocity * Time.deltaTime);
        rb.MovePosition(transform.position + playerMovement);

    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Sky")
        {
            isOnGround = true;
            currentJump = 0; 
        }
    }

    
}
