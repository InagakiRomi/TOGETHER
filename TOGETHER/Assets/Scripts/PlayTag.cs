using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayTag : MonoBehaviour
{
    private GM GM;
    private GameAudio BGM;
    private GameAudio SE;
    public GameObject GameoverImage, Door, Entrance,Girl,Key,Index;
    public bool gameover, entrance;
    public Text txtGoal;

    void Start()
    {
        GM = GameObject.Find("GM").GetComponent<GM>();
        BGM = GameObject.Find("BGM").GetComponent<GameAudio>();
        SE = GameObject.Find("SE").GetComponent<GameAudio>();
        txtGoal.text = "收集寶石";
        gameover = false;
        entrance = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            GameoverImage.SetActive(false);
        }

        if (GM.Score == 0 && entrance == false)
        {
            SE.PLAYchange02();
            txtGoal.text = "拿大門鑰匙";
            Destroy(Door.gameObject);
        }
    }

    public void GameOver()
    {
        gameover = true;
        GM.talk = true;
        GameoverImage.SetActive(true);
        BGM.PLAYchange01();
    }

    public void GetKey()
    {
        entrance = true;
        txtGoal.text = "從大門逃出";
        Index.SetActive(true);
        Destroy(Girl.gameObject);
        Destroy(Entrance.gameObject);
        Destroy(Key.gameObject);
    }
}
