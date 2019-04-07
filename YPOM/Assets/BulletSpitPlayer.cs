using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpitPlayer : MonoBehaviour
{
    Transform point; //цель
    public float speed = 10; //скорость полета пули
    public float range = 10;
    public int damage = 1; //урон от одной пули
    Vector3 pos;
    public GameObject Puddle;
    bool flag_puddle = true;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, pos) > 0.5f) //пока пуля не достигла места назначения
            Move(); //движение пули
        else if (flag_puddle) //если лужи еще нет
        {
            Destroy(gameObject); //удаление пули
            GameObject puddle = Instantiate(Puddle); //создание лужи
            puddle.transform.position = pos; //место появления лужи
            puddle.GetComponent<Renderer>().material.color = Color.blue; //цвет лужи
            flag_puddle = false;
        }
    }

    public void SetTarget(GameObject point) //установка цели
    {
        pos = point.transform.position + transform.forward * range; //позиция конечного пункта пули
        pos.y -= 0.5f; //высота персонажа
    }

    void Move()
    {
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World); //перемещение
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<HealthPoints>();
            player.TakeDamage();
            //other.GetComponent<HealthPoints>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
