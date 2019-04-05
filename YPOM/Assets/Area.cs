using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public string name_area;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
            collision.gameObject.GetComponent<AreaVisited>().Check(name_area);
    }
}
