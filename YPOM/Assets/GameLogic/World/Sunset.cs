﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunset : MonoBehaviour
{

    static public float day_time = 15f;   //время для дневной и ночной фазы
    static public float night_time = 6f;
    static public float dayCount = 0f;
    public static float rot = 0f;//текуще вращение
    float z;
    public float sun_speed;//скорость "солнца"
    public static bool day = true;//день или ночь сейчас
    void Start()
    {
        sun_speed = 180f / day_time; //скорость вращния утром
    }
    void Update()
    {

        if (rot >= 360f)
        {                    //сброс вращеия при полном обороте
            day_time += 5;   //увеличения дялтельности дня
            rot -= 360f;
            dayCount++;
        }
        if (rot < 180)//заход 
        {
            day = true;
            sun_speed = 180f / day_time;
        }

        if (rot > 180)//восход
        {
            day = false;
            sun_speed = 180f / night_time;

        }

        z = sun_speed * Time.deltaTime;
        transform.Rotate(Vector3.right, z);
        rot += z;

    }
}