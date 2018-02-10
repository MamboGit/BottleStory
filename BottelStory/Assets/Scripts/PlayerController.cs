using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Rigidbody2D myRigidbody;

    public float jumpSpeed;
    public Transform groundCheck;

    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;

    void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
        theLevelManager = FindObjectOfType<LevelManager>();

        respawnPosition = transform.position;
    }
	
	
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            
        }

        

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillPlane")
        {
            // gameObject.SetActive(false);
            theLevelManager.Respawn();
            //transform.position = respawnPosition;
        }
        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }












}

