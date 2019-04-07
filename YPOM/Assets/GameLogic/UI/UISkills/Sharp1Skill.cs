using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sharp1Skill : MonoBehaviour, IPointerDownHandler
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
        if (player.GetComponent<Sharp1>() == null)
        {
            player.AddComponent<Sharp1>();
            image.sprite = Resources.Load<Sprite>("sharp");
            SkillIMG = Resources.Load<Texture>("sharp");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}