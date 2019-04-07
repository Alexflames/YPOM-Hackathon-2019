using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsLearnedGetImages : MonoBehaviour
{
    public RawImage[] images;
    // Start is called before the first frame update
    void Awake()
    {
        images = GetComponentsInChildren<RawImage>();
    }
}
