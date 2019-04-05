using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public int healthp = 3;
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