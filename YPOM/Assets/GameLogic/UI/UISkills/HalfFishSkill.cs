using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HalfFishSkill : MonoBehaviour, IPointerDownHandler
{
    GameObject player;
    public Image image;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.GetComponent<WalkWaterScript>() == null)
        {
            player.AddComponent<WalkWaterScript>();
            image.sprite = Resources.Load<Sprite>("halffish");
        }
    }
}