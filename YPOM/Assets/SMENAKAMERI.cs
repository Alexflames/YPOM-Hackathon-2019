using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SMENAKAMERI : NetworkBehaviour
{
    public Camera player;
    public Camera spectate;
    void Start()
    {
        player = GameObject.Find("Camera").GetComponent<Camera>();
        player.enabled = true;
        spectate.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        if (Input.inputString.IndexOf("o") != -1)
        {
            GameObject.Find("Canvas").SetActive(false);
            player.enabled = false;
            spectate.enabled = true;
        }
    }
}
