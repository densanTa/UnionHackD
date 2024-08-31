using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ReturnTitle : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip returnSE;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }


    public void OnRetry(){
        audiosource.PlayOneShot(returnSE);
        Invoke("ReturnTitlepush",1.0f);
    }

    public void ReturnTitlepush(){
        Timecounter_a.score_1 = 0;
        Timecounter_b.score_2 = 0;
        Timecounter_c.score_3 = 0;
        Timecounter_d.score_4 = 0;
        SceneManager.LoadScene("Title");
    }
}
