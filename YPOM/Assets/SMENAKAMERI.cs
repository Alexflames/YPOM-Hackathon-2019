using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMENAKAMERI : MonoBehaviour
{
    public Camera player;
    public Camera spectate;
    void Start()
    {
        player.enabled = true;
        spectate.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString.IndexOf("o") != -1)
        {
            player.enabled = false;
            spectate.enabled = false;
        }
    }
}
