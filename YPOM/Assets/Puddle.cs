using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public float CurrCooldown; //временное КД
    public float Cooldown; //общее КД

    void Start()
    {
        Invoke("Delete_Puddle", 30); //исчезновение лужи
    }

    void OnTriggerStay(Collider collision) //столкновение с лужей
    {
        var player = collision.GetComponent<HealthPoints>();
        if (collision.tag == "Player") //если игрок наступил в лужу
        {
            if (CurrCooldown > 0) //есть ли КД
                CurrCooldown -= Time.deltaTime; //уменьшение КД
            else
            {
                player.TakeDamage();
                CurrCooldown = Cooldown;
            }
        }
        if (collision.tag == "enemy") //если моб наступил в лужу
           Destroy(GameObject.FindGameObjectWithTag("enemy")); //уничтожение мобов

    }

    void Delete_Puddle() //исчезновение лужи
    {
        Destroy(gameObject); //уничтожение объекта
    }
}
