using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioClip change01, change02, change03;
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PLAYchange01()
    {
        audiosource.clip = change01;
        audiosource.Play();
    }

    public void PLAYchange02()
    {
        audiosource.clip = change02;
        audiosource.Play();
    }

    public void PLAYchange03()
    {
        audiosource.clip = change03;
        audiosource.Play();
    }
}
