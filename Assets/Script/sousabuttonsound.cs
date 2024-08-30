using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sousabuttonsound : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip sousaSE;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnsousaPush(){
        audiosource.PlayOneShot(sousaSE);
    }
}
