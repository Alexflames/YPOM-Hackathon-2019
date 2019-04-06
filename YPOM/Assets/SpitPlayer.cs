using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitPlayer : MonoBehaviour
{
    float range = 20; //радиус атаки
    public float CurrCooldown; //временное КД
    public float Cooldown; //общее КД
    public GameObject Bullet;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (CurrCooldown > 0) //есть ли КД
            CurrCooldown -= Time.deltaTime; //уменьшение КД
    }

    void Shoot(Transform enemy) //функция выстрела
    {
        CurrCooldown = Cooldown; //обновление КД
        GameObject bul = Instantiate(Bullet); //создание пули
        bul.transform.position = transform.position; //место появления пули
        //bul.GetComponent<BulletSpitPlayer>().SetTarget(enemy);
    }
}
