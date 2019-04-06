using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public GameObject skillTree;
    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetActive(false);
    }

    // Update is called once per frame
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
