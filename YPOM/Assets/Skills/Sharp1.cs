using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharp1: MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayerStats>().damage += 5; 
    }
}