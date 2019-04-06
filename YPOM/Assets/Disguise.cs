using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disguise : MonoBehaviour
{
    //Color _color;
    //Material Red;
    public float CurrWait; //временное КД
    public float Wait; //общее КД
    Renderer[] renderers;
    bool flag = true;
    void Start()
    {
        //Red = Resources.Load<Material>("Red");
        //gameObject.GetComponent<Renderer>().material = Red;
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
            CurrWait -= Time.deltaTime; //уменьшение КД
        else
            if (flag)
                foreach (var renderer in renderers)
                {
                    var clr = renderer.material.color;
                    clr.a = 0.3f;
                    renderer.material.color = clr;
                    flag = false;
                }
        if (Input.anyKey) //если нажата любая кнопка
        {
            CurrWait = Wait; //сброс ожидания
            flag = true;
        }
        //print(_color.a);
        //_color = gameObject.GetComponent<Renderer>().material.color;
        //if (_color.a > 0)
        //    _color.a -= 1;
        //else
        //    print("Yce");
        //_color.a = 5;
        //gameObject.GetComponent<Renderer>().material.color = _color;
    }
}
