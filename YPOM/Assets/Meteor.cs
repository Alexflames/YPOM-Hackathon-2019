using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Vector3 pos;
    float speed = 15;
    bool flag = true;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red; //метеорит "горячий"
        Fall();
    }

    void OnCollisionEnter(Collision collision) //столкновение
    {
        //if ((gameObject.GetComponent<Renderer>().material.color == Color.red) && (collision.collider.tag == "Player")) //если метеорит "горячий" и соприкасается с игроком
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Destr>().TakeDamage(1); //нанесение урона игроку
        if ((gameObject.GetComponent<Renderer>().material.color == Color.red) && (collision.collider.tag == "enemy")) //если метеорит "горячий" и соприкасается с мобом
            Destroy(GameObject.FindGameObjectWithTag("enemy")); //уничтожение мобов
        Invoke("Cooling", 15); //остывание
        Invoke("Delete", 30); //исчезновение
    }

    void Cooling() //остывание
    {
        GetComponent<Renderer>().material.color = Color.green; //смена цвета при остывании
    }

    void Delete() //исчезновение
    {
        Destroy(gameObject); //уничтожение объекта
    }

    void Fall()
    {
        float x = Random.Range(-100.0f, 100.0f); //координата падения
        float z = Random.Range(-100.0f, 100.0f); //координата падения
        pos = new Vector3(x, 0.1f, z);
    }

    void Move()
    {
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed); //перемещение
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, pos) > 1.4f && flag) //пока метеор не достиг места назначения
            Move(); //движение
        else
            flag = false;
    }
}