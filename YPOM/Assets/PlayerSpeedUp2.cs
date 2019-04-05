using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp2 : MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayerStats>().playerspeed += 10; //увеличение скорости
    }
}
