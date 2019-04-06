using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubica_Root : MonoBehaviour
{
    public float stun_cd = 6f;
    public float time_to_stan = 0;
    public float stun_duration = 3f;
    float stun_end = 0;
    float speed;
    Ubica_agr enemy;
    PlayerStats playerStats;

    void Start()
    {
        enemy = gameObject.GetComponent<Ubica_agr>();
    }

    // Update is called once per frame
    void Update()
    {
        time_to_stan += Time.deltaTime;
        GameObject player = enemy.min_dist;
        playerStats = player.GetComponent<PlayerStats>();
        var range = GetComponent<SphereCollider>();
        if (playerStats.playerspeed == 0)
        {
            stun_end += Time.deltaTime;
            if (stun_end >= stun_duration)
                playerStats.playerspeed = speed;
        }
            if (Vector3.Distance(transform.position, player.transform.position) <= range.radius)
            {
                if (time_to_stan >= stun_cd)
            {
                speed = playerStats.playerspeed;
                    playerStats.playerspeed = 0;
                    time_to_stan = 0;
                }
            }
            else
                time_to_stan = 0;
    }

}
