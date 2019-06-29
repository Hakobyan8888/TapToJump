using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public float moveSpeed;
    public float moveSpeedMax;
    private float moveSpeedStore;
    public float speedMultiplier;


    public float speedIncreaseMilestonemultiplier;
    public float speedMargin;

    public float speedIncreaseMilestone;
    public float speedIncreaseMiletoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stopedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Collider2D myCollider;

    private Animator myAnimator;

    public GameManagaer1 theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter=jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;

        speedIncreaseMiletoneStore = speedIncreaseMilestone;

        stopedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

        // grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedIncreaseMilestonemultiplier;

            moveSpeed = moveSpeed * speedMultiplier; 
        }

        if (speedMargin <= moveSpeed)
        {
            speedMultiplier = 1;
        }
        if(moveSpeedMax <= moveSpeed)
        {
            moveSpeed = moveSpeedMax;
        }


        myRigidbody.velocity = new Vector2(moveSpeed,myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stopedJumping = false;
                jumpSound.Play();
            }
            if (!grounded && canDoubleJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stopedJumping = false;
                canDoubleJump = false;
                jumpSound.Play();
            }
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stopedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)|| Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stopedJumping = true;
        }
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Ground",grounded);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "KillBox")
        {
            theGameManager.ResartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMiletoneStore;
            deathSound.Play();
        }
    }

}
