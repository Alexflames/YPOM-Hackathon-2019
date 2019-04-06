﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_detect : MonoBehaviour
{
    public List<GameObject> gameObjects;
    int counter = 0;

    void OnTriggerEnter(Collider collision)
    {
        if (!gameObjects.Contains(collision.gameObject) && !collision.gameObject == gameObject)
        {
            gameObjects.Add(collision.gameObject);
            counter++;
        }
        if (counter >= 100)
        {
            CleanGarbage();
            counter = 0;
        }
    }

    void CleanGarbage()
    {
        int n = gameObjects.Count;
        for (int i = 0; i < n; i++)
        {
            if (gameObjects[i] == null)
            {
                gameObjects.RemoveAt(i);
                n--;
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        gameObjects.Remove(collision.gameObject);
    }

    public List<GameObject> GetCollidingObjects()
    {
        return gameObjects;
    }
}