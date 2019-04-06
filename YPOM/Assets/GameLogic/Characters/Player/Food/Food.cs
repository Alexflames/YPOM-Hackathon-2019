using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    PlayerStats stats;
    SpawnFruits pref;
    private void OnTriggerEnter(Collider player)
    {
        stats = player.GetComponent<PlayerStats>();
        pref = GameObject.FindGameObjectWithTag("Tree").GetComponent<SpawnFruits>();
        stats.nutrients += 5;
        stats.food_count++;
        Destroy(gameObject);
        pref.countfruits--;
    }
}