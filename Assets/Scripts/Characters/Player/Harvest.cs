using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    PlayerMovement moveScript;
    Rigidbody2D rb;

    [SerializeField] float offsetDist = 1f;
    [SerializeField] float pickUpZone = 1.5f;

    private void Awake()
    {
        moveScript = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CropGrowth.maxGrowth == true) //Checks to see that its on the last sprite in the Grow script
        {
            ChopDown();
            
        }
      
    }

    void ChopDown()
    {
        Vector2 pos = rb.position + moveScript.direction * offsetDist; //player faces the direction they were cutting ...hopefully
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, pickUpZone);

        foreach (Collider2D c in colliders) //checks to see if the player collider is colliding with the plant ~~ I think - Kaz
        {
            Tool hit = c.GetComponent<Tool>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
