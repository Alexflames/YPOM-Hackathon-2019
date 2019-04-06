using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharp3Up : MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayerStats>().damage += 15;
    }
}