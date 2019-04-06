using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public Transform[] points;
    public float boss_speed = 4f;
    public float distance = 0f;
    private int current_point;
    Player_detect bot;
    GameObject player;
    public List<GameObject> players;
    public float min_distance = float.MaxValue;
    GameObject min_dist;
    public float boss_agr_range = 20f;

    private void Start()
    {
        bot = gameObject.GetComponentInChildren<Player_detect>();
        points = new Transform[3] { point1.transform, point2.transform, point3.transform };
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
        if (Vector3.Distance(transform.position, min_dist.position) <= boss_agr_range && Vector3.Distance(transform.position, min_dist.position) >= 5f) ;
        {
            transform.position = Vector3.MoveTowards(transform.position, min_dist.transform, boss_speed * Time.deltaTime);
        }
            if (current_point == points.Length) current_point = 0;
        distance = Vector3.Distance(transform.position, points[current_point].position);
        if (distance <= 0) current_point++;
        transform.LookAt(points[current_point].position);
        transform.position = Vector3.MoveTowards(transform.position, points[current_point].position, boss_speed * Time.deltaTime);
    }
}
