using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gonextstage2 : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip start2SE;
    public TypingManager typingManager;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void Onselectstage2()
    {
        audiosource.PlayOneShot(start2SE);
        selecter.sel = 2;
        Invoke("GoSelectStage",1.0f);
    }

    private void GoSelectStage2(){
        SceneManager.LoadScene("SampleScene2");
    }
}
