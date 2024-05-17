using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryMagneticFieldRedScript : MonoBehaviour
{
    public BlueMovementScript playerScriptBlue;

    public AreaEffector2D areaEffector2D;

    void Update()
    {
        if(playerScriptBlue.magnetStatusBlue)
        {
            areaEffector2D.colliderMask = 64;
        }
        else
        {
            areaEffector2D.colliderMask = 0;
        }
    }
}
