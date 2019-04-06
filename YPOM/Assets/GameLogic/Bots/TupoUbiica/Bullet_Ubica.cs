using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ubica : MonoBehaviour
{
    float speed = 10; //скорость полета пули
    //int damage = ; //урон от одной пули
    Vector3 pos;
    public GameObject Puddle;
    bool flag_puddle = true;
    HealthPoints stats;
    Ubica_agr player;
    public GameObject enemy;
    public GameObject parent;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        player = parent.GetComponent<Ubica_agr>();
        enemy = player.min_dist;
    }

    void Update()
    {
       

        if (Vector3.Distance(transform.position, enemy.transform.position) < 1f) //если пуля достигла цели
        {
            stats = enemy.GetComponent<HealthPoints>();
            stats.healthp--;
            Destroy(gameObject); //удаление пули
        }
        if (Vector3.Distance(transform.position, pos) > 0.5f)
        {//пока пуля не достигла места назначения
            Move(); //движение пули
        }
        else
            Destroy(gameObject); //удаление пули
    }

    public void SetTarget(GameObject enemy) //установка цели
    {
        pos = enemy.transform.position; //позиция объекта (на момент выстрела)
        pos.y -= 0.5f; //высота персонажа

    }

    void Move()
    {
        print("bolwoi");
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed); //перемещение
    }
}
