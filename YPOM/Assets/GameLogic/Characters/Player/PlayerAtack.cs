using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAtack : MonoBehaviour
{
    public float m_Cooldown = 0.5f;
    private float cooldown = 0;
    public int AttackPower = 1;
    public GameObject colliderCube;
    public Enemy_detect CC_simpleAttack;
    PlayerStats playerstats;
    AI_stats bot;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        playerstats = gameObject.GetComponent<PlayerStats>();
        anim = GetComponentInChildren<Animation>();
    }

    void Attack()
    {
        cooldown = m_Cooldown;
        //anim.Play("Take 002");
        CmdAttack();
    }

   
    void CmdAttack()
    {
        int cnt = 0;
        List<GameObject> colGameObjects;
        colGameObjects = CC_simpleAttack.GetCollidingObjects();
        RpcTest(colGameObjects.Count);
        foreach (var obj in colGameObjects)
        {
            var HP = obj.GetComponent<HealthPoints>();
            if (HP) 
            {
                print("lol");
                HP.TakeDamage();
                if (obj == null && obj.tag == "Player")
                {
                    playerstats.kills_count++;

                    playerstats.nutrients += 30;
                }
                else if (obj == null && obj.tag == "Bot")
                {
                    bot = obj.GetComponent<AI_stats>();
                    playerstats.creeps_count++;
                    playerstats.nutrients += 15 * bot.bot_lvl;
                }
                
            }
        }
    }

 
    void RpcTest(int cnt)
    {
        print(cnt);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if ((Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) && cooldown <= 0)
        {
            print("kek");
            Attack();
        }
    }
}