using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrowth : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public Sprite[] sprites;
    public int currentSprite;

    public float timer;
    public float maxTimer = 4f;

    private bool canGrow = true;
    public bool maxGrowth = false;

    // Update is called once per frame
    void Update()
    {
        if (canGrow)
        {
            timer += Time.deltaTime;
        }


        GrowingGreen();
        if (currentSprite == sprites.Length) //currently works if the sprite is on number 8
        {
            maxGrowth = true;
           
        }
    }

    void GrowingGreen()
    {
        if (timer > maxTimer && currentSprite < sprites.Length)
        {
            currentSprite++;
            spriteRend.sprite = sprites[currentSprite];

            if (currentSprite == sprites.Length)
            {
                currentSprite = sprites.Length;
                canGrow = false;
            }
            timer = 0;
        }
    }
}
