using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gonextstage4 : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip start4SE;
    public TypingManager typingManager;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void Onselectstage4()
    {
        audiosource.PlayOneShot(start4SE);
        selecter.sel = 4;
        Invoke("GoSelectStage4",1.0f);
    }

    private void GoSelectStage4(){
        SceneManager.LoadScene("SampleScene4");
    }
}
