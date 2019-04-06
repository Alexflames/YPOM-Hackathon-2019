using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpSkill : MonoBehaviour, IPointerDownHandler
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.GetComponent<Jump>() == null)
            player.AddComponent<Jump>();
    }
}