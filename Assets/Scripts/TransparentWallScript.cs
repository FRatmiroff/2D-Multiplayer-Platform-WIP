using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.U2D.IK;
using UnityEngine;
using UnityEngine.U2D;

public class TransparentWallScript : MonoBehaviour
{
    public SpriteRenderer wallRenderer; // Assign the wall's SpriteRenderer in the inspector
    private int playersInside = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Make sure your player GameObjects have the tag "Player"
        {
            playersInside++;
            UpdateWallTransparency();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersInside--;
            UpdateWallTransparency();
        }
    }

    private void UpdateWallTransparency()
    {
        if (playersInside > 0)
        {
            wallRenderer.color = new Color(wallRenderer.color.r, wallRenderer.color.g, wallRenderer.color.b, 0.5f); // Semi-transparent
        }
        else
        {
            wallRenderer.color = new Color(wallRenderer.color.r, wallRenderer.color.g, wallRenderer.color.b, 1f); // Opaque
        }
    }
    
    /*private Color col;
    public GameObject wall;
    private float t;

    private new SpriteShapeRenderer renderer;
    private Color lerpCol;
    private bool invisible;
    private bool visible;
    private Color white;

    void Start()
    {
        renderer = wall.GetComponent<SpriteShapeRenderer>();
        t = 1.0f;
        Color col = new Color(1.0f, 1.0f, 1.0f, t);
        renderer.material.color = col;
        invisible = false;
        visible = true;
        Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    void FixedUpdate()
    {
        
    }

    public void makeVisible()
    {
        invisible = false;
        visible = true;
        StartCoroutine("Visibility");
    }

    public void makeInvisible()
    {
        invisible = true;
        visible = false;
        StartCoroutine("Invisibility");
    }

    IEnumerator Invisibility()
    {
        if(invisible && renderer.color.a > 0.41f)
        {
            for(float i = 1f; i >= 0.4f; i -= 0.001f)
            {
                col = renderer.color;
                col.a = i;
                renderer.color = col;

                yield return new WaitForSeconds(0.0001f);
            }
        } else {
            
        }
    }

    IEnumerator Visibility()
    {
        if(visible && renderer.color.a < 1f)
        {
            for(float i = 0.4f; i <= 1f; i += 0.001f)
            {
                col = renderer.color;
                col.a = i;
                renderer.color = col;

                yield return new WaitForSeconds(0.0001f);
            }
        } else {
            
        }
    }*/
}
