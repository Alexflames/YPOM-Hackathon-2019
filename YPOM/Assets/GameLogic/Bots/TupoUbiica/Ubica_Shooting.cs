using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ubica_Shooting : MonoBehaviour
{
    public float CurrCooldown; //временное КД
    public float Cooldown; //общее КД
    public GameObject Bullet;
    Ubica_agr vrag;

    void Update()
    {
        if (CanShoot()) //если можно стрелять
            SearchTarget(); //поиск врага

        if (CurrCooldown > 0) //есть ли КД
            CurrCooldown -= Time.deltaTime; //уменьшение КД
    }

    bool CanShoot() //может ли враг стрелять в данный момент
    {
        if (CurrCooldown <= 0) //есть ли КД
            return true;
        return false;
    }

    void SearchTarget() //поиск цели
    {
        vrag = gameObject.GetComponent<Ubica_agr>();
        GameObject enemy = vrag.min_dist; //поиск врага (гг)
        var range = GetComponentInChildren<CapsuleCollider>();
        float currDistance = Vector3.Distance(transform.position, enemy.transform.position);
        if (currDistance <= range.radius) //если враг в радиусе
            Shoot(enemy); //выстрел по нему
    }

    void Shoot(GameObject enemy) //функция выстрела
    {
        CurrCooldown = Cooldown; //обновление КД
        GameObject bul = Instantiate(Bullet); //создание пули
        bul.transform.position = transform.position; //место появления пули
        bul.GetComponent<Bullet_Ubica>().parent = gameObject;
        bul.GetComponent<Bullet_Ubica>().SetTarget(enemy);
    }
}