using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpSkill : MonoBehaviour, IPointerDownHandler
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
        if (player.GetComponent<Jump>() == null)
        {
            player.AddComponent<Jump>();
            image.sprite = Resources.Load<Sprite>("jump");
            SkillIMG = Resources.Load<Texture>("jump");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}