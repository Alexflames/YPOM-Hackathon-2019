using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetAI_attack : NetworkBehaviour
{
    NetAI_agr enemy;
    NetHP player_HP;
    public int attackPower = 5;
    public float bot_atack_range = 6f;
    public float bot_cast_time = 3f;
    float bot_cast_time_left;
    public float bot_cast_cd = 3f;

    void Start()
    {
        enemy = gameObject.GetComponent<NetAI_agr>();
        bot_cast_time_left = bot_cast_time;
    }


    void Update()
    {
        GameObject player = enemy.min_dist;
        if (player == null) return;
        player_HP = player.GetComponent<NetHP>();
        if (Vector3.Distance(transform.position, player.transform.position) <= bot_atack_range)
        {
            bot_cast_time_left -= Time.deltaTime;
            CastAnim(bot_cast_time_left);
            if (bot_cast_time_left <= 0)
            {
                player_HP.TakeDamage(attackPower);
                GetComponent<Renderer>().material.color = Color.red;
                bot_cast_time_left = bot_cast_time;
            }
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > bot_atack_range)
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
