using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryMagneticFieldBlueScript : MonoBehaviour
{
    public RedMovementScript playerScriptRed;

    public AreaEffector2D areaEffector2D;

    void Update()
    {
        if(playerScriptRed.magnetStatusRed)
        {
            areaEffector2D.colliderMask = 128;
        }
        else
        {
            areaEffector2D.colliderMask = 0;
        }
    }
}
