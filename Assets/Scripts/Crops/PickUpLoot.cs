using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLoot : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 2f;
    [SerializeField] float pickUpDistance = 2.5f;
    [SerializeField] float despawnTime = 10f;

    private void Awake()
    {
        player = GameManager.instance.player.transform; //gets a reference to the player
    }

    private void Update()
    {
        despawnTime -= Time.deltaTime; //countdown
        if (despawnTime < 0)
        {
            Destroy(gameObject); //destroys self if its not picked up after 10 seconds (this could be reduced)
        }

        float lootDist = Vector3.Distance(transform.position, player.position);
        if (lootDist > pickUpDistance) //just makes the loot sit still
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //will chase the player down so its easier to pickup for inventory
        if (lootDist < 0.1f)
        {
            Destroy(gameObject); //destroys on pickup
        }
    }
}
