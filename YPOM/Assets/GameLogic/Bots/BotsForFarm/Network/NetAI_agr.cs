using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetAI_agr : MonoBehaviour
{
    Player_detect bot;
    NetAI_stats stats;
    public float bot_agr_range = 10f;
    public float bot_speed;
    GameObject player;
    public GameObject min_dist = null;
    public float distance;
    public float min_distance = float.MaxValue;
    public List<GameObject> players;
    Transform target;
    public Animation anim;
    void Start()
    {
        bot = gameObject.GetComponentInChildren<Player_detect>();
        stats = gameObject.GetComponent<NetAI_stats>();
    }


    void Update()
    {
        players = bot.GetCollidingObjects();
        foreach (var obj in players)
        {
            if (obj == null) continue;
            distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < min_distance)
            {
                min_distance = distance;
                min_dist = obj;
            }
        }
        if (min_dist != null && Vector3.Distance(transform.position, min_dist.transform.position) <= bot_agr_range)
        {
            target = min_dist.transform;
            transform.LookAt(target);
            if (anim.isPlaying == false)
                anim.Play("Take 001");
            transform.position = Vector3.MoveTowards(transform.position, min_dist.transform.position, stats.bot_move_speed * Time.deltaTime);
        }
        else
        {
            min_dist = null;
            min_distance = float.MaxValue;
        }
    }


}
