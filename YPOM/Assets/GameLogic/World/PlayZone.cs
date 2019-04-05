using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoBehaviour
{
    GameObject player;
    HealthPoints player_stats;
    public float time_to_next_zone = 5f;
    public float moving_time = 0f;
    public float new_radius;
    public float zone_number = 1f;
    public bool in_zone = true;
    void Start()
    {
        var zone = GetComponent<CapsuleCollider>();
        new_radius = zone.radius - 1f;
    }
    void Update()
    {
        var zone = GetComponent<CapsuleCollider>();

        if (moving_time >= time_to_next_zone)
        {
            if (zone.radius >= new_radius)
            {
                zone.radius -= 0.1f * Time.deltaTime;
            }
            else
            {
                zone_number++;
                moving_time = 0;
                new_radius = zone.radius - 1f * zone_number;
            }
        }
        else
            moving_time += Time.deltaTime;
        if (!in_zone)
        {
            player_stats = player.GetComponent<HealthPoints>();
            player_stats.healthp -= 0.001f * zone_number;
        }
    }

    void OnTriggerExit(Collider other)
    {
        in_zone = false;
            player = other.gameObject;
    }
}   