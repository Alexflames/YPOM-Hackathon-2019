﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shooting : MonoBehaviour
{
    public float CurrCooldown; //временное КД
    public float Cooldown; //общее КД
    public GameObject Bullet;
    Boss_Move vrag;

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
        vrag = gameObject.GetComponent<Boss_Move>();
        GameObject enemy = vrag.min_dist; //поиск врага (гг)
        var range = GetComponentInChildren<CapsuleCollider>();
        if (enemy == null)
            return;
        float currDistance = Vector3.Distance(transform.position, enemy.transform.position);
        if (currDistance <= range.radius) //если враг в радиусе
            Shoot(enemy); //выстрел по нему
    }

    void Shoot(GameObject enemy) //функция выстрела
    {
        CurrCooldown = Cooldown; //обновление КД
        GameObject bul = Instantiate(Bullet); //создание пули
        bul.transform.position = transform.position; //место появления пули
        bul.GetComponent<Boss_Bullet>().parent = gameObject;
        bul.GetComponent<Boss_Bullet>().SetTarget(enemy);

    }
}