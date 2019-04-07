using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetHP : NetworkBehaviour
{
    [SyncVar]
    public float healthp = 20;
    public int maxhealthp = 20;

    public void TakeDamage(int hp)
    {
        healthp -= hp;
        if (healthp <= 0)
        {
            var npa = GetComponent<NetPlayerAttack>();
            if (npa != null)
            {
                npa.AttackPower = 0;
                GetComponent<NetRealMove>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                transform.Rotate(180, 0, 0, Space.World);
                if (isLocalPlayer)
                {
                    var cameraAttach = GetComponent<NetworkCameraAttach>();
                    cameraAttach.PlayerCamera.transform.parent = null;
                    cameraAttach.PlayerCamera.SetActive(true);
                    cameraAttach.TreeCamera.SetActive(false);
                    cameraAttach.enabled = false;
                    var NMST = GameObject.Find("Canvas").GetComponent<NetManageSkillTree>();
                    NMST.SkillTree.SetActive(false);
                    NMST.enabled = false;
                }
                
            }
            else
            {
                NetworkServer.Destroy(gameObject);
            }
        }
    }
}