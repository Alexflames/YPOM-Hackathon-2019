using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetHP : NetworkBehaviour
{
    [SyncVar]
    public float healthp = 20;
    public int maxhealthp = 20;

    public void TakeDamage(int hp)
    {
        healthp -= hp;
        if (healthp <= 0)
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}