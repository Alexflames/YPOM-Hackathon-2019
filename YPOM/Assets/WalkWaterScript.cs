using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkWaterScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayerStats>().walkwater = true; //плавание по воде (увеличение скорости)
    }
}