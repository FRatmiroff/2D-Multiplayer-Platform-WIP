using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magneticSurfaceScript : MonoBehaviour
{
    public BlueMovementScript playerScriptBlue;
    public RedMovementScript playerScriptRed;

    public AreaEffector2D areaEffector2D;

    void Update()
    {
        if(playerScriptBlue.magnetStatusBlue && playerScriptRed.magnetStatusRed)
        {
            areaEffector2D.colliderMask = 192;
        }
        else if(playerScriptBlue.magnetStatusBlue)
        {
            areaEffector2D.colliderMask = 64;
        }
        else if(playerScriptRed.magnetStatusRed)
        {
            areaEffector2D.colliderMask = 128;
        }
        else
        {
            areaEffector2D.colliderMask = 0;
        }
    }
}
