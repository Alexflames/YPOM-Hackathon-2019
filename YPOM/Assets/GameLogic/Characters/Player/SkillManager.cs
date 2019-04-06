using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Image Skill1;
    public Image Skill2;
    public Image Skill3;
    public Image Skill4;
    bool is1 = false;
    bool is2 = false;
    bool is3 = false;
    bool is4 = false;


    public KeyCode AddSkill(Sprite img)
    {
        if (is1 == false)
        {
            is1 = true;
            Skill1.sprite = img;
            return KeyCode.Alpha1;
        }
        else if (is2 == false)
        {
            is2 = true;
            Skill2.sprite = img;
            return KeyCode.Alpha2;
        }
        else if (is3 == false)
        {
            is3 = true;
            Skill3.sprite = img;
            return KeyCode.Alpha3;
        }
        else if (is4 == false)
        {
            is4 = true;
            Skill4.sprite = img;
            return KeyCode.Alpha4;
        }
        else return KeyCode.Escape;
    }
}