using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semanager1 : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip CloseSE;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void closeSemanager(){
        audiosource.PlayOneShot(CloseSE);
    }
}
