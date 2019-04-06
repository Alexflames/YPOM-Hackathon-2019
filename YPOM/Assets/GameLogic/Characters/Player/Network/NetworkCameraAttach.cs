using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCameraAttach : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerCamera;
    void Start()
    {
        if (!isLocalPlayer) return;
        PlayerCamera = GameObject.Find("Camera");
        PlayerCamera.transform.position = transform.position + new Vector3(0, 10, -4);
        PlayerCamera.transform.parent = gameObject.transform;
    }
}
