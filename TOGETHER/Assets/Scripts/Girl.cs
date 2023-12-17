using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;

public class Girl : MonoBehaviour
{
    private GM GM;
    private PlayTag PlayTag;
    private Transform PlayerTr;
    private NavMeshAgent nvAgent;

    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GM>();
        PlayTag = GameObject.Find("GM").GetComponent<PlayTag>();
        if (GM.Level == GM.LevelScence.level02)
        {
            PlayerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
            nvAgent = GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        if (GM.Level == GM.LevelScence.level02)
        {
            nvAgent.destination = PlayerTr.position;
        }
    }

    void HitByRaycast() //被射線打到時會進入此方法
    {
        if (GM.talk == false && GM.Level == GM.LevelScence.level01)
        {
            Flowchart.BroadcastFungusMessage("平常對話");
        }
    }

    void OnCollisionEnter(UnityEngine.Collision coll)
    {
        if (GM.Level == GM.LevelScence.level02)
        {
            if (coll.gameObject.tag == "Player")
            {
                PlayTag.GameOver();
                Destroy(gameObject);
            }
        }
    }
}
