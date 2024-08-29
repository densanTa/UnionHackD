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
    void Start()
    {
        gameOverText.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(FinishSE);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        timeText.text = countdown.ToString("f1") + "";

       
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

}
