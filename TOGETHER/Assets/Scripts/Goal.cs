using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public enum GoalType
    {
        Candy, Jewel, Key
    }
    public GoalType type;
    private GM GM;
    private PlayTag PlayTag;
    private GameAudio SE;

    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GM>();
        PlayTag = GameObject.Find("GM").GetComponent<PlayTag>();
        SE = GameObject.Find("SE").GetComponent<GameAudio>();
    }

    void HitByRaycast() //被射線打到時會進入此方法
    {
        if (type == GoalType.Candy)
        {
            SCORE();
        }
        if (type == GoalType.Key)
        {
            SE.PLAYchange03();
            PlayTag.GetKey();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (type == GoalType.Jewel)
            {
                SE.PLAYchange01();
                SCORE();
            }
        }
    }
    void SCORE()
    {
        GM.DisplayScore(-1);
        Destroy(gameObject);
    }
}
