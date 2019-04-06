using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraWheel : MonoBehaviour
{
    FreeCamera freecam;
    void Start()
    {
        freecam = GameObject.FindGameObjectWithTag("Helper").GetComponent<FreeCamera>();
    }

    void Update()
    {
        if (freecam.activecam == true)
        {
            float sw = Input.GetAxis("Mouse ScrollWheel");
            if (sw > 0.1)
            {
                transform.position += transform.forward * Time.deltaTime * 100;
            }
            if (sw < -0.1)
            {
                transform.position -= transform.forward * Time.deltaTime * 100;
            }
        }
    }
}
