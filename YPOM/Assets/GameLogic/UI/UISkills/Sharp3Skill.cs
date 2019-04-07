using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sharp3Skill : MonoBehaviour, IPointerDownHandler
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
        if (player.GetComponent<Sharp3Up>() == null)
        {
            player.AddComponent<Sharp3Up>();
            image.sprite = Resources.Load<Sprite>("sharp3");
            SkillIMG = Resources.Load<Texture>("sharp3");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}