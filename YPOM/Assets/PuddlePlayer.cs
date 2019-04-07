using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddlePlayer : MonoBehaviour
{
    void Start()
    {
        Invoke("Delete_Puddle", 10); //исчезновение лужи
    }

    void OnCollisionEnter(Collision collision) //столкновение с лужей
    {
        //if (collision.collider.tag == "Player") //если игрок наступил в лужу
        //GameObject.FindGameObjectWithTag("Player").GetComponent<>().TakeDamage(1); //нанесение урона игроку
        if (collision.collider.tag == "enemy") //если моб наступил в лужу
            Destroy(GameObject.FindGameObjectWithTag("enemy")); //уничтожение мобов

    }

    void Delete_Puddle() //исчезновение лужи
    {
        Destroy(gameObject); //уничтожение объекта
    }
}
