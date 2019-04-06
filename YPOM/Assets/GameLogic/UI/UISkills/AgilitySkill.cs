using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AgilitySkill : MonoBehaviour, IPointerDownHandler
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.GetComponent<Agility>() == null)
            player.AddComponent<Agility>();
    }
}