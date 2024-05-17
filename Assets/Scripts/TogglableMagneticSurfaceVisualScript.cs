using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglableMagneticSurfaceVisualScript : MonoBehaviour
{
    public SwitchButtonScript switchScript;
    public SpriteRenderer surface;

    void Start()
    {
        surface.color = new Color(1.0f, 0.4f, 0.33f, 1.0f);
    }
    void Update()
    {
        if(switchScript.magneticStatus)
        {
            surface.color = new Color(0.33f, 0.8f, 1.0f, 1.0f);
        }
        else if(!switchScript.magneticStatus)
        {
            surface.color = new Color(1.0f, 0.4f, 0.33f, 1.0f);
        }
    }
}
