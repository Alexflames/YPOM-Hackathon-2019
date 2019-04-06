using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubica_agr : MonoBehaviour
{
    Player_detect bot;
    AI_stats stats;
    GameObject player;
   public GameObject min_dist = null;
    public float distance;
   public float min_distance = float.MaxValue;
    public List<GameObject> players;
    HealthPoints bot_hp;

    void Start()
    {
        bot = gameObject.GetComponentInChildren<Player_detect>();
        stats = gameObject.GetComponent<AI_stats>();
        bot_hp = gameObject.GetComponent<HealthPoints>();
    }


    void Update()
    {

        players = bot.GetCollidingObjects();
        foreach (var obj in players)
        {
            distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < min_distance)
            {
                min_distance = distance;
                min_dist = obj;
            }
        }
        var range = GetComponentInChildren<SphereCollider>();
        if (min_dist != null && Vector3.Distance(transform.position, min_dist.transform.position) <= range.radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, min_dist.transform.position, stats.bot_move_speed * Time.deltaTime);
        }
        else if (min_dist != null && Vector3.Distance(transform.position, min_dist.transform.position) >= range.radius)
        {
            min_dist = null;
            min_distance = float.MaxValue;
        }
    //    else if (bot_hp.healthp <= 6)
    //        transform.position = Vector3.MoveTowards(transform.position, min_dist.transform.position * 4f, stats.bot_move_speed * Time.deltaTime);
    }

  
}
