using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliderscript : MonoBehaviour
{
    HealthPoints health;
    Slider healthbar;
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPoints>();
        healthbar = GetComponent<Slider>();
    }

    void Update()
    {
        healthbar.value = health.healthp;
    }
}