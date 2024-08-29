using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
        public static int score = 0;

    void Start()
    {
        ScoreText.text = ""+score;
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
        score -= 40;

        ScoreText.text = "" + score;
    }

    
}
