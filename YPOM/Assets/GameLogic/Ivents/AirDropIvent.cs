using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropIvent : MonoBehaviour
{
    public float time_to_ivent = 10f;
    public float time_left;
    bool grav;

    GameObject bot;
  
    void Update()
    {
        time_left += Time.deltaTime;
        if (time_left >= time_to_ivent)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
   
}
