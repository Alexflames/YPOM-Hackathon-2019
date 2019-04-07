using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetManageSkillTree : NetworkBehaviour
{
    public GameObject SkillTree;
    public GameObject BackgroundTree;
    private Renderer BTRend;
    public float r1, r2, g1, g2, b1, b2, a;
    NetSunset sunSetScr;
    // Start is called before the first frame update
    void Start()
    {
        BTRend = BackgroundTree.GetComponent<Renderer>();
        sunSetScr = GameObject.Find("Sunset").GetComponent<NetSunset>();
        SkillTree.SetActive(false);
        r1 = 136; r2 = 255;
        g1 = 242; g2 = 136;
        b1 = 245; b2 = 225;
        a = BTRend.material.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (!NetSunset.day)
        {
            SkillTree.SetActive(true);
            float proportion = (sunSetScr.rot - 180) / 180.0f;
            BTRend.material.color =
                new Color(
                    (r1 + (r2 - r1) * proportion) / 255, 
                    (g1 + (g2 - g1) * proportion) / 255, 
                    (b1 + (b2 - b1) * proportion) / 255, a);
            //print(BTRend.material.color);
        }
        else if (NetSunset.day)
        {
            BTRend.material.color = new Color(r1 / 255, g1 / 255, b1 / 255, a);
            SkillTree.SetActive(false);
        }
    }
}
