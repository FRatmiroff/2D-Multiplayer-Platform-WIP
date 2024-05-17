using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlueMovementScript : MonoBehaviour
{
    // private Rigidbody2D BlueRB;

    // public Animator animator;
    // AudioManager audioManager;
    // public ParticleSystem dustJump;
    // public ParticleSystem dustRun;

    // private float moveSpeed;
    // private float jumpForce;
    // private bool isJumping = false;
    // private float moveHorizontal;
    // private float moveVertical;
    // private float switchStatus;
    // private float interact;

    // private float speed;
    // bool isLadder = false;
    // public bool touchingButton = false;
    // public bool touchingMPButton = false;

    // public bool magnetStatusBlue;
    // private float hasSwitched;

    // public bool isControllerConnected;
    // String controlStatus;

    // public Transform currentCheckpoint;

    // void Awake()
    // {
    //     audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    // }

    // void Start()
    // {
    //     BlueRB = gameObject.GetComponent<Rigidbody2D>();

    //     moveSpeed = 3f;
    //     jumpForce = 30f;
    //     isJumping = false;

    //     magnetStatusBlue = true;
    //     animator.SetBool("MagneticStatus", true);

    //     if(isControllerConnected)
    //     {
    //         controlStatus = "Horizontal_Controller";
    //     } else {
    //         controlStatus = "Horizontal";
    //     }
    // }

    // void Update()
    // {
    //     moveHorizontal = Input.GetAxisRaw(controlStatus);
    //     moveVertical = Input.GetAxisRaw("Vertical");
    //     switchStatus = Input.GetAxisRaw("SwitchStatus");
    //     interact = Input.GetAxisRaw("Interact");

    //     animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

    //     if(Input.GetButtonDown("SwitchStatus"))
    //     {
    //         magnetStatusBlue = !magnetStatusBlue;
    //         animator.SetBool("MagneticStatus", magnetStatusBlue);
    //     }
    //     Debug.Log("touchingMPButton: " + touchingMPButton);
    //     if(Mathf.Abs(moveHorizontal) > 0.3f && !isJumping)
    //     {
    //         PlayDustRun();
    //     }
    // }

    // void FixedUpdate()
    // {
    //     if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
    //     {
    //         BlueRB.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
    //         if(moveHorizontal > 0.3f) {transform.localScale = new Vector2(2.5f, 2.5f);}
    //         if(moveHorizontal < -0.3f) {transform.localScale = new Vector2(-2.5f, 2.5f);}
    //     } else if(moveHorizontal > -0.3f && moveHorizontal < 0.3f && !isJumping) {
    //         BlueRB.velocity = Vector2.zero;
    //     }

    //      if(moveVertical > 0.1f && !isJumping && !isLadder)
    //     {
    //          BlueRB.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
    //          audioManager.PlaySound(audioManager.jump);
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.CompareTag("Platform"))
    //     {
    //         isJumping = false;
    //         animator.SetBool("IsJumping", false);
    //         PlayDustJump();
    //     }

    //     if(collision.gameObject.tag == "Climbable")
    //     {
    //         isLadder = true;
    //     }

    //     if(collision.gameObject.name == "MovingPlatformButton1" || collision.gameObject.name == "MovingPlatformButton2")
    //     {
    //         touchingMPButton = true;
    //     }

    //     if(collision.gameObject.tag == "Checkpoint")
    //     {
    //         if(collision.gameObject.name == "CP1")
    //         {
    //             currentCheckpoint = collision.gameObject.GetComponent<Transform>();
    //         }
    //     }

    //     if(collision.gameObject.tag == "Death")
    //     {
    //         Death();
    //     }
    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if(collision.CompareTag("Platform"))
    //     {
    //         isJumping = true;
    //         animator.SetBool("IsJumping", true);
    //         PlayDustJump();
    //     }

    //     if(collision.gameObject.tag == "Climbable")
    //     {
    //         isLadder = false;
    //     }

    //     if(collision.gameObject.name == "MovingPlatformButton1" || collision.gameObject.name == "MovingPlatformButton2")
    //     {
    //         touchingMPButton = false;
    //     }
    // }


    // void Death()
    // {
    //     Vector2 respawn = currentCheckpoint.transform.position;
    //     respawn.y -= 5;
    //     gameObject.transform.position = respawn;
    // }

    // void PlayDustJump()
    // {
    //     dustJump.Play();
    // }
    // void PlayDustRun()
    // {
    //     dustRun.Play();
    // }

    private Rigidbody2D BlueRB;

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

    public bool magnetStatusBlue;
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
        BlueRB = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 3f;
        jumpForce = 30f;
        isJumping = false;

        magnetStatusBlue = true;
        animator.SetBool("MagneticStatus", true);

        if(isControllerConnected)
        {
            controlStatus = "Horizontal_Controller";
        } else {
            controlStatus = "Horizontal";
        }
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw(controlStatus);
        moveVertical = Input.GetAxisRaw("Vertical");
        switchStatus = Input.GetAxisRaw("SwitchStatus");
        interact = Input.GetAxisRaw("Interact");

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        if(Input.GetButtonDown("SwitchStatus") && magnetStatusControllable)
        {
            magnetStatusBlue = !magnetStatusBlue;
            animator.SetBool("MagneticStatus", magnetStatusBlue);
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
            BlueRB.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            if(moveHorizontal > 0.3f) {transform.localScale = new Vector2(2.5f, 2.5f);}
            if(moveHorizontal < -0.3f) {transform.localScale = new Vector2(-2.5f, 2.5f);}
        }

        if(moveVertical > 0.1f && !isJumping && !isLadder)
        {
            BlueRB.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
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