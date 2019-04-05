using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerStats experience;
    Slider expbar;
    void Start()
    {
        experience = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        expbar = GetComponent<Slider>();
    }

    void Update()
    {
        expbar.value = experience.exp;
    }
}