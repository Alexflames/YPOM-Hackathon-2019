using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agility : MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayerStats>().playerspeed += 5; //увеличение скорости 
    }
}
