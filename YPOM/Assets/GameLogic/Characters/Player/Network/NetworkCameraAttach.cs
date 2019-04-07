using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCameraAttach : NetworkBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerCamera;
    public GameObject TreeCamera;

    void Start()
    {
        if (!isLocalPlayer) return;
        PlayerCamera = GameObject.Find("Camera");
        TreeCamera = GameObject.Find("CameraTree");
        PlayerCamera.transform.position = transform.position + new Vector3(0, 12, -7);
        PlayerCamera.transform.parent = gameObject.transform;
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        if (!NetSunset.day)
        {
            PlayerCamera.SetActive(false);
            TreeCamera.SetActive(true);
        }
        else
        {
            PlayerCamera.SetActive(true);
            TreeCamera.SetActive(false);
        }
    }
}
