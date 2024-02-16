using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropGrowth : MonoBehaviour
{
    public SpriteRenderer spriteRend;
    public Sprite[] sprites;
    public static int currentSprite;

    public float timer;
    public float maxTimer = 4f;

    private bool canGrow = true;
    public static bool maxGrowth = false;
    public static bool resetGrowth = false;

    // Update is called once per frame
    void Update()
    {
        if (canGrow)
        {
            timer += Time.deltaTime;
        }

        if (resetGrowth == true)
        {
            currentSprite = 0;
        }

        GrowingGreen();
        if (currentSprite == sprites.Length) //checks to see if the current Growth spite is on the last one in the array
        {
            maxGrowth = true;
            CropCutDown.lootAmount = 3;
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
                currentSprite = sprites.Length; //here so it doesnt go past sprites length and keeps it at the same length until harvested
                canGrow = false;
            }
            timer = 0;
        }
    }
}
