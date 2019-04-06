using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharp2 : MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayerStats>().damage += 10;
    }
}