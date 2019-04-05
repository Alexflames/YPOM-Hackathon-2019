using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    PlayerStats stats;
    private void OnTriggerEnter(Collider player)
    {
        stats = player.GetComponent<PlayerStats>();
        stats.nutrients += 5;
        stats.food_count++;
        Destroy(gameObject);
    }
}
