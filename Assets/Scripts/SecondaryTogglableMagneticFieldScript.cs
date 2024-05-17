using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryTogglableMagneticFieldScript : MonoBehaviour
{
    public SwitchButtonScript switchScript;
    
    public BlueMovementScript playerScriptBlue;
    public RedMovementScript playerScriptRed;

    public AreaEffector2D areaEffector2D;

    void Update()
    {
        if(switchScript.magneticStatus)
        {
            if(playerScriptBlue.magnetStatusBlue)
            {
                areaEffector2D.colliderMask = 128;
            }
            else
            {
                areaEffector2D.colliderMask = 0;
            }
        }
        else if(!switchScript.magneticStatus)
        {
            if(playerScriptRed.magnetStatusRed)
            {
                areaEffector2D.colliderMask = 64;
            }
            else
            {
                areaEffector2D.colliderMask = 0;
            }
        }
    }
}
