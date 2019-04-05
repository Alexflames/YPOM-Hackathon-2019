using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCamera : MonoBehaviour
{
    public bool TEAM_VIEWER_USED = true;
    private Vector3 lastMousePos = new Vector3();
    void Update()
    {
        if (TEAM_VIEWER_USED)
        {
            int sign = Input.mousePosition.x > lastMousePos.x ? 1 : -1;
            float dx = Vector3.Distance(Input.mousePosition, lastMousePos);
            transform.Rotate(Vector3.up, sign * dx / 10, Space.World);
            lastMousePos = Input.mousePosition;
        }
    }
}
