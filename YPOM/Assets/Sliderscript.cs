using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliderscript : MonoBehaviour
{
    GameObject player;
    HealthPoints health;
    Slider healthbar;
    void Awake()
    {
        health = GameObject.Find("Cube").GetComponent<HealthPoints>();
        healthbar = GetComponent<Slider>();
    }

    void Update()
    {
        healthbar.value = health.healthp;
    }
}