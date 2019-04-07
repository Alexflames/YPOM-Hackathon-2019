using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Vector3 pos_1; //1 позиция прыжка
    Vector3 pos_2; //2 позиция прыжка
    Vector3 direction;
    public float length; //дальность прыжка
    public float height; //высота прыжка
    float speed = 20; //скорость полета
    int flag = -1;
    public Texture SkillIMG;
    SkillManager manager;
    KeyCode key;

    void Start()
    {
        SkillIMG = Resources.Load<Texture>("jump");
        key = GetComponent<SkillManager>().AddSkill(SkillIMG);
    }
    
    void Update()
    {
        print(flag);
        if (Input.inputString.IndexOf('q') != -1)
            Update_Position(); //обновление позиции

        if (flag == 0)
        {
            if (Vector3.Distance(transform.position, pos_1) > 0.5f) //пока 1 стадия прыжка
                Move(pos_1); //движение
            else
                flag = 1;
        }
        if (flag == 1)
        {
            if (Vector3.Distance(transform.position, pos_2) > 0.5f) //пока 2 стадия прыжка
                Move(pos_2); //движение
            else
                flag = -1;
        }
    }

    void Move(Vector3 pos)
    {
        print(pos);
        direction = pos - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World); //перемещение
    }

    void Update_Position()
    {
        pos_1 = transform.position + transform.forward * length / 2;
        pos_1.y += height;
        pos_2 = transform.position + transform.forward * length;
        flag = 0;
    }
}
