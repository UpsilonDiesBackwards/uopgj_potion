using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropCutDown : Tool //using Tool here so override works
{
    [SerializeField] GameObject loot;
    [SerializeField] int lootAmount = 3;
    [SerializeField] float spread = 2f;

    public override void Hit() //changes the Hit function in the Tool script
    {
        while (lootAmount > 0)
        {
            lootAmount -= 1; //reduces the amount of lootspawn on function Hit
            Vector3 pos = transform.position; //sets the Loot object position to the Object position that this script is attached to
            pos.x += spread * UnityEngine.Random.value - spread / 2; //changes where the loot is spread out so its not all clumped together
            pos.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(loot); //spawns whatever loot object is attached to this which can change depending on ingredient harvested
            go.transform.position = pos;
        }

        Destroy(gameObject); //destroys the plant object so the ingredient object can spawn
    }
}