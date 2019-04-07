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
    public float maximum = 3200f;
    public float minimum = 1900;
    float t = 0;
    void Start()
    {
        var zone = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        var zone = GetComponent<CapsuleCollider>();
        if (moving_time >= time_to_next_zone && zone_number != 3)
        {
            t += Time.deltaTime;
            {
                if (transform.parent.localScale.x != minimum)
                {
                    transform.parent.localScale = new Vector3(Mathf.Lerp(maximum, minimum, t / 20), Mathf.Lerp(maximum, minimum, t / 20), 100);
                }
                else
                {
                    t = 0;
                    maximum = minimum;
                    zone_number++;
                    moving_time = 0;
                    minimum = maximum - 1300; ;
                }
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