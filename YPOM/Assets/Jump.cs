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

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.inputString.IndexOf('q') != -1)
            Update_Position(); //обновление позиции

        if (flag == 0)
        {
            if (Vector3.Distance(transform.position, pos_1) > 0.5f) //пока 1 стадия прыжка
                Move(pos_1); //движение
            else
                flag = 1;
        }
        else if (flag == 1)
        {
            if (Vector3.Distance(transform.position, pos_2) > 0.5f) //пока 2 стадия прыжка
                Move(pos_2); //движение
        }
    }

    void Move(Vector3 pos)
    {
        print(pos);
        direction = pos - transform.forward;
        transform.Translate(direction.normalized * Time.deltaTime * speed); //перемещение
    }

    void Update_Position()
    {
        Vector3 direction = gameObject.transform.forward;
        pos_1 = transform.position;
        pos_1.z += length / 2f;
        pos_1.y += height;
        pos_2 = transform.position;
        pos_2.z += length;
        pos_2.y -= 0.5f;
        flag = 0;
    }
}
