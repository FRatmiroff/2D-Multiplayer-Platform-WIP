using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButtonScript : MonoBehaviour
{
    public bool magneticStatus = true;

    private bool touchingRed = false;
    private bool touchingBlue = false;

    void Update()
    {
        // Switch(KeyCode.Q, touchingBlue);
        // Switch(KeyCode.U, touchingRed);
        Switch("Interact", touchingBlue);
        Switch("Interact2", touchingRed);

        if(Input.GetButtonDown("Interact"))
        {
            //Debug.Log("Button Pressed");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Red")
        {
            touchingRed = true;
        }
        if(collision.gameObject.name == "Blue")
        {
            touchingBlue = true;
            //Debug.Log("Touching Blue");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Red")
        {
            touchingRed = false;
        }
        if(collision.gameObject.name == "Blue")
        {
            touchingBlue = false;
        }
    }

    void Switch(KeyCode key, bool colortouch)
    {
        if(Input.GetKeyDown(key))
        {
            if(colortouch)
            {
                magneticStatus = !magneticStatus;
            }
        }
    }

    void Switch(String key, bool colortouch)
    {
        if(Input.GetButtonDown(key))
        {
            if(colortouch)
            {
                magneticStatus = !magneticStatus;
                //Debug.Log("Switch True");
            } else {
                //Debug.Log("Switch False");
                //Debug.Log("Colortouch: " + colortouch + ", Touchingblue: " + touchingBlue);
            }
        }
    }
}
