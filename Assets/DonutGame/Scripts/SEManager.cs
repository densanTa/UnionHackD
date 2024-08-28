using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip dropSE;

    // Start is called before the first frame update
    void Start()
    {
        audiosource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(dropSE);
        }
    }
}
