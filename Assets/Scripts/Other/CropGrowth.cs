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

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTimer)
        {
            currentSprite++;
            spriteRend.sprite = sprites[currentSprite];

            if (currentSprite >= sprites.Length)
            {
                currentSprite = 0;

            }
            timer = 0;
        }
    }
}
