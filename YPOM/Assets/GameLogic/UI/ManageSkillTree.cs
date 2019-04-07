using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSkillTree : MonoBehaviour
{
    public GameObject SkillTree;
    public Material BackgroundTree;
    // Start is called before the first frame update
    void Start()
    {
        SkillTree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Sunset.day)
        {
            SkillTree.SetActive(true);
        }
        else if (Sunset.day)
        {
            SkillTree.SetActive(false);
        }
    }
}
