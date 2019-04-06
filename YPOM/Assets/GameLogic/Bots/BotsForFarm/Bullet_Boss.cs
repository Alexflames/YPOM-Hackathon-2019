using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss : MonoBehaviour
{
    float speed = 10; //скорость полета пули
    //int damage = ; //урон от одной пули
    Vector3 pos;
    public GameObject Puddle;
    bool flag_puddle = true;
    HealthPoints stats;
    Boss_Move player;
    GameObject enemy;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        player = gameObject.GetComponent<Boss_Move>();
        enemy = player.min_dist;
        if (Vector3.Distance(transform.position, enemy.transform.position) < 1f) //если пуля достигла цели
        {
            stats = enemy.GetComponent<HealthPoints>();
            stats.healthp--;
            Destroy(gameObject); //удаление пули
        }
        if (Vector3.Distance(transform.position, pos) > 0.5f) //пока пуля не достигла места назначения
            Move(); //движение пули
        else
            Destroy(gameObject); //удаление пули
    }

    public void SetTarget() //установка цели
    {
        pos = enemy.transform.position; //позиция объекта (на момент выстрела)
        pos.y -= 0.5f; //высота персонажа
    }

    void Move()
    {
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed); //перемещение
    }
}
