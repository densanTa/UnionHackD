using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController_a : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
        public static int score_a = 0;
    
    private AudioSource audiosource;
    public AudioClip MissSE;

    void Start()
    {
        score_a = 0;
        ScoreText.text = ""+score_a;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore_a(){
        score_a += 10;

        ScoreText.text = "" + score_a;
    }

    public void SubScore_a(){
        score_a -= 30;

        ScoreText.text = "" + score_a;

        audiosource.PlayOneShot(MissSE);
    }

    
}
