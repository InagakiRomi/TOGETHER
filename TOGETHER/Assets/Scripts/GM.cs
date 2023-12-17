using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class GM : MonoBehaviour
{
    public enum LevelScence
    {
        level01, level02
    }
    public LevelScence Level;

    private GameAudio BGM;
    public bool talk;
    public Text txtScore;
    public int Score;

    public GameObject AIM;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        BGM = GameObject.Find("BGM").GetComponent<GameAudio>();
        if (Level == LevelScence.level01)
        {
            DisplayScore(11);
        }
        if (Level == LevelScence.level02)
        {
            DisplayScore(160);
        }
    }

    public void TalkOn()
    {
        talk = true;
        if (AIM != null)
        {
            AIM.SetActive(false);
        }
    }
    public void TalkOff()
    {
        talk = false;
        if (AIM != null)
        {
            AIM.SetActive(true);
        }
    }

    public void DisplayScore(int score)
    {
        Score += score;
        txtScore.text = Score.ToString();
        if (Score == 0)
        {
            if (Level == LevelScence.level01)
            {
                BGM.PLAYchange01();
                Flowchart.BroadcastFungusMessage("第二關開頭");
            }
        }
    }
}
