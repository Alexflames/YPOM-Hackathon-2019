using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    bool flag = true;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Sea" && flag && GetComponent<PlayerStats>().walkwater == false) //если море и скилла хождения по воде нет
        {
            print("В воде скорость уменьшается");
            flag = false;
            GetComponent<PlayerStats>().playerspeed -= 5; //уменьшение скорости в воде
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Sea" && !flag && GetComponent<PlayerStats>().walkwater == false) //если не море и нет скилла хождения по воде нет
        {
            GetComponent<PlayerStats>().playerspeed += 5; //увеличение скорости не в воде
            flag = true;
        }
    }
}
