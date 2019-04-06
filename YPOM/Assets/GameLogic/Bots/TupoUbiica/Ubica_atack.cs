using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubica_atack : MonoBehaviour
{
    HealthPoints bot;
    Ubica_agr enemy;
    PlayerStats playerstats;
    public float bot_cast_time = 7f;
    float bot_cast_time_left;
    Shooting attack;
    public float stun_duration = 3f;
    float speed;
    float stun_left = 3.1f;
    GameObject player;

    void Start()
    {
        enemy = gameObject.GetComponent<Ubica_agr>();
        bot_cast_time_left = bot_cast_time;
        bot = gameObject.GetComponent<HealthPoints>();
        player = enemy.min_dist;
        playerstats = player.GetComponent<PlayerStats>();
        speed = playerstats.playerspeed;
    }


    void Update()
    {
       
       
        var range = GetComponentInChildren<CapsuleCollider>();
        if (stun_left <= stun_duration)
        {
            stun_left -= Time.deltaTime;
            if (stun_left <= 0f)
            {
                stun_left = 3.1f;
                playerstats.playerspeed = speed;
            }

        }   
        if (Vector3.Distance(transform.position, player.transform.position) <= range.radius)
        {
            bot_cast_time_left -= Time.deltaTime;
            CastAnim(bot_cast_time_left);
            if (bot_cast_time_left <= 0)
            {
                playerstats.playerspeed = 0;
                bot_cast_time_left = bot_cast_time;
                stun_left -= 0.1f;
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > range.radius)
        {
            GetComponent<Renderer>().material.color = Color.red;
            bot_cast_time_left = bot_cast_time;
        }
    }
    void CastAnim(float bot_cast_time_left)
    {
        if (bot_cast_time_left >= 2f)
            GetComponent<Renderer>().material.color = Color.green;
        else if (bot_cast_time_left >= 1f)
            GetComponent<Renderer>().material.color = Color.yellow;
        else
            GetComponent<Renderer>().material.color = Color.blue;
    }
}
