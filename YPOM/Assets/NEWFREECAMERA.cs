using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWFREECAMERA : MonoBehaviour
{
    PlayerStats stats;
    float speed;
    public bool activecam;
    public int cameraspeed = 5;
    bool moved;
    Vector3 lastMousePos = new Vector3();
    NetCamera netcam;
    void Start()
    {

    }
    void MoveByButton(char key, Vector3 dir, ref bool moved)
    {
        if (Input.inputString.IndexOf(key) != -1)
        {
            transform.Translate(dir * cameraspeed * 10 * Time.deltaTime, Space.World);
            moved = true;
        }
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
    void MoveByButtonThird(char key, int x)
    {
        if (Input.inputString.IndexOf(key) != -1)
        {
            transform.position -= -x * transform.up * Time.deltaTime * 100;
        }
    }

    void Update()
    {
            MoveByButton('w', transform.forward, ref moved);
            MoveByButton('d', transform.right, ref moved);
            MoveByButton('a', -transform.right, ref moved);
            MoveByButton('s', -transform.forward, ref moved);
            MoveByButtonSecond('q', cameraspeed);
            MoveByButtonSecond('e', -cameraspeed);
            float sw = Input.GetAxis("Mouse ScrollWheel");
            if (sw > 0.1)
            {
                var rotation = transform.eulerAngles;
                rotation.x += 10;
                transform.eulerAngles = rotation; ;
            }
            if (sw < -0.1)
            {
                var rotation = transform.eulerAngles;
                rotation.x -= 10;
                transform.eulerAngles = rotation;
            }
            MoveByButtonThird('=', 1);
            MoveByButtonThird('-', -1);
    }
}
