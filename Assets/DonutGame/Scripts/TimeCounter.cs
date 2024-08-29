using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    public SpawnPrefab donutgenerator;
    public TypingManager typingmanager;
    public float countdown = 90.0f;
    public GameObject gameOverText;

    public Text timeText;

    private AudioSource audiosource;
    public AudioClip FinishSE;
    private bool isPose = true;
    public bool isPlaying = false;
    
    void Start()
    {
        gameOverText.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        donutgenerator.isPlaying = false;
        typingmanager.isPlaying = false;
        Invoke("StartUP",4.0f);
        Invoke("FinishSESounder",countdown + 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
         if (isPose)
        {
            return;
        }
        countdown -= Time.deltaTime;

        timeText.text = countdown.ToString("f1") + "";


            if(countdown == 0){
                
            }
            if (countdown <= 0)
        {
            timeText.text = "Finish!";
            donutgenerator.isPlaying = false;
            typingmanager.isPlaying = false;
            gameOverText.SetActive(true);
            Invoke("ChangeScene", 4.0f);
        }

       
       
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Result");
    }
    void FinishSESounder(){
        audiosource.PlayOneShot(FinishSE);
    }
    
    void StartUP(){
        isPose = false;
        donutgenerator.isPlaying = true;
        typingmanager.isPlaying = true;
    }

}
