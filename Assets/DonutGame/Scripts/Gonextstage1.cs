using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gonextstage1 : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip start1SE;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void Onselectstage1()
    {
        audiosource.PlayOneShot(start1SE);
        selecter.sel = 1;
        Invoke("GoSelectStage",1.0f);
    }

    private void GoSelectStage(){
        SceneManager.LoadScene("SampleScene1");
    }
}
