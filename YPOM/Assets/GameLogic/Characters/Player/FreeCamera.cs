using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    PlayerStats stats;
    float speed;
    bool activecam;
    bool moved;
    Camera freecamera;
    Vector3 lastMousePos = new Vector3();
    NetCamera netcam;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        netcam = GameObject.FindGameObjectWithTag("Player").GetComponent<NetCamera>();
        freecamera = GetComponent<Camera>();
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    void MoveByButtonFirst(char key)
    {
        if (Input.inputString.IndexOf(key) != -1)
        {
            if (!activecam)
            {
                speed = stats.playerspeed;
                stats.playerspeed = 0;
                activecam = true;
                netcam.freecam = true;
            }
            else
            {
                stats.playerspeed = speed;
                activecam = false;
                netcam.freecam = true;
            }

        }
    }
    void MoveByButtonSecond(char key, int x)
    {
        if (Input.inputString.IndexOf(key) != -1)
        {
            transform.Rotate(Vector3.up, -x, Space.World);
        }
    }
    void MoveByButton(char key, Vector3 dir, ref bool moved)
    {
        if (Input.inputString.IndexOf(key) != -1)
        {
            transform.Translate(dir * 50 * Time.deltaTime, Space.World);
            moved = true;
        }
    }

    void Update()
    {
        MoveByButtonFirst('o');
        if (activecam == true)
        {
            MoveByButton('w', transform.up, ref moved);
            MoveByButton('d', transform.right, ref moved);
            MoveByButton('a', -transform.right, ref moved);
            MoveByButton('s', -transform.up, ref moved);
            MoveByButtonSecond('q', -5);
            MoveByButtonSecond('e', 5);
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
