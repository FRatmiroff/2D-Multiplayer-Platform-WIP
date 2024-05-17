using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MovableMovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    [SerializeField] float speed;

    bool move = false;

    public BlueMovementScript BMS;
    public RedMovementScript RMS;

    int direction = 1;

    private void Update()
    {
        Debug.Log("Move: " + move);

        Vector2 target = currentMovementTarget();
        float distance = (target - (Vector2)platform.position).magnitude;

        if(move)
        {
            platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);
            if(distance <= 0.1f)
            {
                move = false;
            }
        }
        if ((BMS.touchingMPButton && Input.GetButtonDown("Interact")) || (RMS.touchingMPButton && Input.GetButtonDown("Interact2")))
        {
            direction *= -1;
            move = true;
            Debug.Log("touching and pressed");
        }
    }

    private void OnDrawGizmos()
    {
        if(platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }

    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return startPoint.position;
        } else {
            return endPoint.position;
        }
    }
}
