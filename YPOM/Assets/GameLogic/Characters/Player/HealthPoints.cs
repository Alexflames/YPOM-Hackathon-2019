using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public float healthp = 20;
    public int maxhealthp = 3;

    public void TakeDamage()
    {
        healthp--;
        if (healthp <= 0)
        {
            Destroy(gameObject);
        }
    }
}