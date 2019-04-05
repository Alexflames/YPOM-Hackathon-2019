using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_agr : MonoBehaviour
{
    Player_detect bot;
    AI_stats stats;
    public float bot_agr_range;
    public float bot_speed;
    GameObject player;
   public GameObject min_dist = null;
    public float distance;
   public float min_distance = float.MaxValue;
    public List<GameObject> players;
    void Start()
    {
        bot = gameObject.GetComponentInChildren<Player_detect>();
        stats = gameObject.GetComponent<AI_stats>();
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
        if (min_dist != null && Vector3.Distance(transform.position, min_dist.transform.position) <= min_distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, min_dist.transform.position, stats.bot_move_speed * Time.deltaTime);
        }
    }

  
}
