using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTime : MonoBehaviour
{
    public Text Clock;
    float hours;
    float minutes;
    void Start()
    {
        
    }

    
    void Update()
    {
        hours = ((Sunset.rot + 90) % 360) / 360.0f * 24;
        minutes = Sunset.rot % 15 / 15.0f * 60;
        Clock.text = ((int)hours).ToString()+":"+ ((int)minutes).ToString();
    }
}
