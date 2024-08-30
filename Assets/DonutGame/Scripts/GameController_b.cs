using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController_b : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
        public static int score_b = 0;
    
    private AudioSource audiosource;
    public AudioClip MissSE;

    void Start()
    {
        score_b = 0;
        ScoreText.text = ""+score_b;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore_b(){
        score_b += 10;

        ScoreText.text = "" + score_b;
    }

    public void SubScore_b(){
        score_b -= 30;

        ScoreText.text = "" + score_b;

        audiosource.PlayOneShot(MissSE);
    }

    
}
