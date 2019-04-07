using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disguise : MonoBehaviour
{
    public float CurrWait; //временное КД
    public float Wait; //общее КД
    Renderer[] renderers;
    public Texture SkillIMG;
    KeyCode key;

    void Start()
    {
        SkillIMG = Resources.Load<Texture>("disguise");
        key = GetComponent<SkillManager>().AddSkill(SkillIMG);
        renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach(var renderer in renderers)
        {
            var clr = renderer.material.color;
            clr.a = 1f;
            renderer.material.color = clr;
        }
    }
    
    void Update()
    {
        if (CurrWait > 0) //есть ли КД
        {
            CurrWait -= Time.deltaTime; //уменьшение КД
            foreach (var renderer in renderers)
            {
                var clr = renderer.material.color;
                clr.a = 3 * CurrWait / 10f + 0.3f;
                //clr.a = 0.3f;
                renderer.material.color = clr;
            }
        }
        if (Input.anyKey) //если нажата любая кнопка
        {
            CurrWait = Wait; //сброс ожидания
            foreach (var renderer in renderers)
            {
                var clr = renderer.material.color;
                clr.a = 1f;
                renderer.material.color = clr;
            }
        }
    }
}
