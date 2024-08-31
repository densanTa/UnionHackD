using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timecounter_a : MonoBehaviour
{
    public SpawnPrefab donutgenerator;
    public TypingManager typingmanager;
    public float countdown = 90.0f;
    public GameObject gameOverText;

    public Text timeText;

    private AudioSource audiosource;
    public AudioClip FinishSE;
    public AudioClip CountdownSE;
    private bool isPose = true;
    public bool isPlaying = false;
    
    public GameObject count_3;
    public GameObject count_2;
    public GameObject count_1;
    public GameObject count_start;

    public static int score_1 = 0;
    void Start()
    {
        gameOverText.SetActive(false);
        count_3.SetActive(false);
        count_2.SetActive(false);
        count_1.SetActive(false);
        count_start.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        donutgenerator.isPlaying = false;
        typingmanager.isPlaying = false;
        Invoke("Count_3on",1.0f);
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
            score_1 = GameController.score;
            Invoke("ChangeScene", 4.0f);
        }

       
       
        
    }

    void ChangeScene()
    {
        Debug.Log(score_1);
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

    void Count_3on(){
        count_3.SetActive(true);
        audiosource.PlayOneShot(CountdownSE);
        Invoke("Count_3off",1.0f);
    }

    void Count_3off(){
        count_3.SetActive(false);
        Count_2on();
    }

    void Count_2on(){
        count_2.SetActive(true);
        Invoke("Count_2off",1.0f);
    }
    void Count_2off(){
        count_2.SetActive(false);
        Count_1on();
    }
    void Count_1on(){
        count_1.SetActive(true);
        Invoke("Count_1off",1.0f);
    }
    void Count_1off(){
        count_1.SetActive(false);
        Count_starton();
    }
    void Count_starton(){
        count_start.SetActive(true);
        Invoke("Count_startoff",1.0f);
    }
    void Count_startoff(){
        count_start.SetActive(false);
    }
}
