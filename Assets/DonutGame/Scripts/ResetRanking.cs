using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResetRanking : MonoBehaviour
{
    private AudioSource audiosource;
    public AudioClip resetSE;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

   
    public void OnReset(){
         audiosource.PlayOneShot(resetSE);
        Invoke("ResetRankingPush",1.0f);
    }

    public void ResetRankingPush(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Title");
    }
}
