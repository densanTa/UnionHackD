using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject blackui;
    private AudioSource audiosource;
    public AudioClip OpenMenuSE;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void OnOpenMenu(){
        blackui.SetActive(true);
        audiosource.PlayOneShot(OpenMenuSE);
    }
}
