using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public Text ScoreText;
    void Start()
    {
        ScoreText.text = "あなたの得点:" + GameController.score; 
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
