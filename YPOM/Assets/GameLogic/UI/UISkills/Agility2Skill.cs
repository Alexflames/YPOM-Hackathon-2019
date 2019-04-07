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
    public CanvasSetPlayer CSP;

    void Awake()
    {
        CSP = GameObject.Find("Canvas").GetComponent<CanvasSetPlayer>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        player = CSP.player;
        if (player.GetComponent<Agility2>() == null)
        {
            player.AddComponent<Agility2>();
            image.sprite = Resources.Load<Sprite>("speed2");
            SkillIMG = Resources.Load<Texture>("speed2");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}