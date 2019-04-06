using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sharp2Skill : MonoBehaviour, IPointerDownHandler
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.GetComponent<Sharp2>() == null)
            player.AddComponent<Sharp2>();
    }
}