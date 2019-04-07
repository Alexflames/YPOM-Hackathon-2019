using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisguiseSkill : MonoBehaviour, IPointerDownHandler
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
        if (player.GetComponent<Disguise>() == null)
        {
            player.AddComponent<Disguise>();
            image.sprite = Resources.Load<Sprite>("disguise");
            SkillIMG = Resources.Load<Texture>("disguise");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}