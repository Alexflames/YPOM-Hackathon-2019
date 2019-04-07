using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AgilitySkill : MonoBehaviour, IPointerDownHandler
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
        if (player.GetComponent<Agility>() == null)
        {
            player.AddComponent<Agility>();
            image.sprite = Resources.Load<Sprite>("speed");
            SkillIMG = Resources.Load<Texture>("speed");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}