using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetMove : MonoBehaviour   //Скрипт для передвижения игрока
{
    PlayerStats stats;
    //MovementParticleEmitter MPE;
    private float MPETimer;

    public bool TEAM_VIEWER_USED = true;

    private float speed;
    private Vector3 lastMousePos = new Vector3();
    public Animation movementAnim;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        movementAnim.GetComponentInChildren<Animation>();
        //MPE = GetComponent<MovementParticleEmitter>();
    }

    void MoveByButton(char key, Vector3 dir, ref bool moved)
    {
        if (Input.inputString.IndexOf(key) != -1)
        {
            transform.Translate(dir * speed * 10 * Time.deltaTime, Space.World);
            moved = true;
        }
    }

    void Update()
    {
        //if (!isLocalPlayer) return;

        if (TEAM_VIEWER_USED)
        {
            MPETimer += Time.deltaTime;
            if (true) //Sunset.day
            {
                speed = stats.playerspeed;
                bool moved = false;
                MoveByButton('w', transform.forward, ref moved);
                MoveByButton('d', transform.right, ref moved);
                MoveByButton('a', -transform.right, ref moved);
                MoveByButton('s', -transform.forward, ref moved);
                if (moved)
                {
                    if (!movementAnim.isPlaying) movementAnim.PlayQueued("Take 001");
                    //MPE.Switch(on: true);
                    MPETimer = 0;
                }
                //else if (MPETimer > 0.5)
                    //MPE.Switch(on: false);
            }
        }
        //else
        //{

        //}
    }
}