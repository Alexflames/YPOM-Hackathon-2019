using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Agility2Skill : MonoBehaviour, IPointerDownHandler
{
    GameObject player;
    Texture SkillIMG;
    public Image image;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.GetComponent<Agility2>() == null)
        {
            player.AddComponent<Agility2>();
            image.sprite = Resources.Load<Sprite>("speed");
            SkillIMG = Resources.Load<Texture>("speed2");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}