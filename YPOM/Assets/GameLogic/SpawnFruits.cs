using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    public int countfruits;
    public GameObject prefab;
    public float time = 1f;
    public float time_now;
    void create()
    {
        float x = Random.Range(gameObject.transform.position.x + 0.8f, gameObject.transform.position.x + 1.6f);
        float z = Random.Range(gameObject.transform.position.z + 0.8f, gameObject.transform.position.z + 1.6f);
        print(gameObject.transform.position.x);
        print(gameObject.transform.position.y);
        print(gameObject.name);
        Instantiate(prefab, new Vector3(x, 0.5f, z), Quaternion.identity);
        countfruits++;
    }
    void Start()
    {
        time_now = time;
    }

    void FixedUpdate()
    {
        time_now -= Time.deltaTime;
        if (time_now <= 0 && countfruits < 3)
        {
            create();
            time_now = time;
        } 
    }
}