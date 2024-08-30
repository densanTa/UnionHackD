using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semanager2 : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip CloseMenuSE;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void closeMenuSEmanager(){
        audiosource.PlayOneShot(CloseMenuSE);
    }
}
