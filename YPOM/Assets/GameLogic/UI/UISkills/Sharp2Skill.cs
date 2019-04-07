using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sharp2Skill : MonoBehaviour, IPointerDownHandler
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
        if (player.GetComponent<Sharp2>() == null)
        {
            player.AddComponent<Sharp2>();
            image.sprite = Resources.Load<Sprite>("sharp2");
            SkillIMG = Resources.Load<Texture>("sharp2");
            player.GetComponent<SquareManager>().AddSkill(SkillIMG);
        }
    }
}