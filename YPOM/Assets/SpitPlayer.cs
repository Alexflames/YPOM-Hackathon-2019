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
        if (CanShoot() && Input.inputString.IndexOf('z') != -1) //если можно стрелять и нажата клавиша
            Shoot(gameObject.transform); //выстрел
        if (CurrCooldown > 0) //есть ли КД
            CurrCooldown -= Time.deltaTime; //уменьшение КД
    }

    bool CanShoot() //может ли враг стрелять в данный момент
    {
        if (CurrCooldown <= 0) //есть ли КД
            return true;
        return false;
    }

    void Shoot(Transform point) //функция выстрела
    {
        CurrCooldown = Cooldown; //обновление КД
        GameObject bul = Instantiate(Bullet, transform.position, transform.rotation); //создание пули
        bul.GetComponent<BulletSpitPlayer>().SetTarget(gameObject);
    }
}
