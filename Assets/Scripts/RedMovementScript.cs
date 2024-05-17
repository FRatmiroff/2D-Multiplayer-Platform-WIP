using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RedMovementScript : MonoBehaviour
{
    private Rigidbody2D RedRB;

    public Animator animator;
    AudioManager audioManager;
    public ParticleSystem dustJump;
    public ParticleSystem dustRun;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping = false;
    private float moveHorizontal;
    private float moveVertical;
    private float switchStatus;
    private float interact;

    private float speed;
    private bool isLadder = false;
    public bool touchingButton = false;
    public bool touchingMPButton = false;

    public bool magnetStatusRed;
    public bool magnetStatusControllable = false;

    public bool isControllerConnected;
    String controlStatus;

    public Transform currentCheckpoint;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        RedRB = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 3f;
        jumpForce = 30f;
        isJumping = false;

        magnetStatusRed = true;
        animator.SetBool("MagneticStatus", true);

        if(isControllerConnected)
        {
            controlStatus = "Horizontal_Controller2";
        } else {
            controlStatus = "Horizontal2";
        }
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw(controlStatus);
        moveVertical = Input.GetAxisRaw("Vertical2");
        switchStatus = Input.GetAxisRaw("SwitchStatus2");
        interact = Input.GetAxisRaw("Interact2");

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        if(Input.GetButtonDown("SwitchStatus2") && magnetStatusControllable)
        {
            magnetStatusRed = !magnetStatusRed;
            animator.SetBool("MagneticStatus", magnetStatusRed);
        }
        if(Mathf.Abs(moveHorizontal) > 0.3f && !isJumping)
        {
            PlayDustRun();
        }
    }

    void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            RedRB.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            if(moveHorizontal > 0.3f) {transform.localScale = new Vector2(2.5f, 2.5f);}
            if(moveHorizontal < -0.3f) {transform.localScale = new Vector2(-2.5f, 2.5f);}
        }

        if(moveVertical > 0.1f && !isJumping && !isLadder)
        {
            RedRB.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
            audioManager.PlaySound(audioManager.jump);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
            PlayDustJump();
        }

        if(collision.gameObject.tag == "Climbable")
        {
            isLadder = true;
        }

        if(collision.gameObject.name == "MovingPlatformButton1" || collision.gameObject.name == "MovingPlatformButton2")
        {
            touchingMPButton = true;
        }

        if(collision.gameObject.tag == "Checkpoint")
        {
            if(collision.gameObject.name == "CP1")
            {
                currentCheckpoint = collision.gameObject.GetComponent<Transform>();
            }
        }

        if(collision.gameObject.tag == "Death")
        {
            Death();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            PlayDustJump();
        }

        if(collision.gameObject.tag == "Climbable")
        {
            isLadder = false;
        }

        if(collision.gameObject.name == "MovingPlatformButton1" || collision.gameObject.name == "MovingPlatformButton2")
        {
            touchingMPButton = false;
        }
    }

    void Death()
    {
        Vector2 respawn = currentCheckpoint.transform.position;
        respawn.y -= 5;
        gameObject.transform.position = respawn;
    }

    void PlayDustJump()
    {
        dustJump.Play();
    }
    void PlayDustRun()
    {
        dustRun.Play();
    }
}
