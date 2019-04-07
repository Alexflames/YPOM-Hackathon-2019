using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareManager : MonoBehaviour
{
    public RawImage[] square = new RawImage[27];
    public bool[] check = new bool[27];

    void Start()
    {
        var Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<CanvasSetPlayer>().LinkToPlayer(gameObject);
        square = Canvas.GetComponentInChildren<SkillsLearnedGetImages>().images;
    }

    public void AddSkill(Texture img)
    {
        print(img);
        for (int i = 0; i < 27; i++)
        {
            if (check[i] == false)
            {
                square[i].texture = img;
                check[i] = true;
                break;
            }
        }
    }
}