using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
        public static int score = 0;
    
    private AudioSource audiosource;
    public AudioClip MissSE;

    void Start()
    {
        score = 0;
        ScoreText.text = ""+score;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(){
        score += 10;

        ScoreText.text = "" + score;
    }

    public void SubScore(){
        score -= 30;

        ScoreText.text = "" + score;

        audiosource.PlayOneShot(MissSE);
    }

    
}
