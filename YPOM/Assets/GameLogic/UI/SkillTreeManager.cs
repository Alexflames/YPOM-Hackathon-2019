using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public GameObject skillTree;
    void Start()
    {
        skillTree.SetActive(false);
    }

    void Update()
    {
        if (!Sunset.day)
        {
            if (!skillTree.activeInHierarchy)
            {
                skillTree.SetActive(true);
            }
        }
        else
        {
            skillTree.SetActive(false);
        }
    }
}
