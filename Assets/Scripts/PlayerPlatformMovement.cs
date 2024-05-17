using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformMovement : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] GameObject blue;
    [SerializeField] GameObject red;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(platform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    // public void Exit(int player)
    // {
    //     Debug.Log("Called");
    //     if(player == 1)
    //     {
    //         red.transform.SetParent(null);
    //     } else if(player == 2) {
    //         blue.transform.SetParent(null);
    //     }
    // }
}
