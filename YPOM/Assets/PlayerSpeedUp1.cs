using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUp1 : MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayerStats>().playerspeed += 5; //увеличение скорости
    }
}
