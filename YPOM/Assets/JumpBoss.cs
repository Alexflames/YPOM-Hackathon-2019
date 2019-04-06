using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoss : MonoBehaviour
{
    Vector3 pos;
    Vector3 direction;
    public float height; //высота прыжка
    float speed = 10; //скорость полета
    bool flag = true;
    public float CurrCooldown; //временное КД
    public float Cooldown; //общее КД

    void Start()
    {

    }

    void Update()
    {
        if (CurrCooldown > 0) //есть ли КД
            CurrCooldown -= Time.deltaTime; //уменьшение КД
        else
        {
            if (flag)
            {
                pos = transform.position;
                flag = false;
                pos.y += height;
            }
            if (Vector3.Distance(transform.position, pos) > 0.5f)
            {
                Move(pos); //движение
            }
            else
            {
                CurrCooldown = Cooldown; //обновление КД
                flag = true;
                // нанесение урона
            }
        }
    }

    void Move(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed); //перемещение
    }
}
