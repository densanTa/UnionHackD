using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip startSE;

     void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void OnClickStartButton()
    {
        audiosource.PlayOneShot(startSE);
        Invoke("GameStartPush",1.0f);
    }

    public void GameStartPush(){
        SceneManager.LoadScene("SampleScene");
    }

    
}