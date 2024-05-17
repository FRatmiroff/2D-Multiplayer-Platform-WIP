using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    bool isLadder = false;
    bool isClimbing = false;

    float moveVertical;
    [SerializeField] String MV;

    void Update()
    {
        moveVertical = Input.GetAxisRaw(MV);

        if(isLadder && moveVertical > 0.1f)
        {
            isClimbing = true;
        }
        //Debug.Log(isLadder);
    }

    void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveVertical * 5f);
        } else {
            rb.gravityScale = 10f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Climbable"))
        {
            isLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Climbable"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
