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
        SceneManager.LoadScene("Title");
    }
}
