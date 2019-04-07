using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetPlayer : MonoBehaviour
{
    public GameObject player;

    public void LinkToPlayer(GameObject player)
    {
        this.player = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
