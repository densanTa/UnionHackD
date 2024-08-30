using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public GameObject backui;
    private AudioSource audiosource;
    public AudioClip OpenSE;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    

    public void Onopen(){
        backui.SetActive(true);
        audiosource.PlayOneShot(OpenSE);
    }
}
