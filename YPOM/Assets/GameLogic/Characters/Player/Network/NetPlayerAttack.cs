using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetPlayerAttack : NetworkBehaviour
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
        anim.CrossFade("Take 001");
        CmdAttack();
    }

    [Command]
    void CmdAttack()
    {
        int cnt = 0;
        List<GameObject> colGameObjects;
        colGameObjects = CC_simpleAttack.GetCollidingObjects();
        RpcTest(colGameObjects.Count);
        foreach (var obj in colGameObjects)
        {
            if (obj == null) continue;
            var HP = obj.GetComponent<NetHP>();
            if (HP)
            {
                bot = obj.GetComponent<AI_stats>();
                var botlv = bot == null ? 0 : bot.bot_lvl;
                HP.TakeDamage(AttackPower);
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

    [ClientRpc]
    void RpcPlayerKilled(GameObject winner)
    {
        var playerstats = winner.GetComponent<PlayerStats>();
        playerstats.kills_count++;
        playerstats.nutrients += 30;
    }

    [ClientRpc]
    void RpcBotKilled(GameObject winner, int botlvl)
    {
        var playerstats = winner.GetComponent<PlayerStats>();
        playerstats.creeps_count++;
        playerstats.nutrients += 15 * botlvl;
    }


    void RpcTest(int cnt)
    {
        print(cnt);
        anim.CrossFade("Take 001");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        cooldown -= Time.deltaTime;
        if ((Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) && cooldown <= 0)
        {
            Attack();
        }
    }
}