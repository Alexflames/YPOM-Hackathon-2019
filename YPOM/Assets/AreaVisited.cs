using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaVisited : MonoBehaviour
{
    Dictionary<string, bool> areas = new Dictionary<string, bool>();
    void Start()
    {
        //GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerStats>();
        //print(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerspeed);
        //GameObject.FindGameObjectWithTag("Player").AddComponent<PlayerSpeedUp1>();
        //print(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerspeed);
        areas.Add("Area_1", false);
        areas.Add("Area_2", false);
    }

    void Update()
    {
        //print(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().playerspeed);
    }

    public void Check(string name_area)
    {
        if (areas[name_area] == false)
        {
            areas[name_area] = true;
            print(name_area + " только что посещена");
            GetComponent<PlayerStats>().exp += 5; //увеличение опыта
        }
        else
            print(name_area + " была посещена ранее");
    }
}
