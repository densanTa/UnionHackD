using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController_c : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
        public static int score_c = 0;
    
    private AudioSource audiosource;
    public AudioClip MissSE;

    void Start()
    {
        score_c = 0;
        ScoreText.text = ""+score_c;
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore_c(){
        score_c += 10;

        ScoreText.text = "" + score_c;
    }

    public void SubScore_c(){
        score_c -= 30;

        ScoreText.text = "" + score_c;

        audiosource.PlayOneShot(MissSE);
    }

    
}
