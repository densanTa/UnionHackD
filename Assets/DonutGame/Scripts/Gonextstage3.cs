using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gonextstage3 : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip start3SE;
    public TypingManager typingManager;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void Onselectstage3()
    {
        audiosource.PlayOneShot(start3SE);
        selecter.sel = 3;
        Invoke("GoSelectStage3",1.0f);
    }

    private void GoSelectStage3(){
        SceneManager.LoadScene("SampleScene3");
    }
}
