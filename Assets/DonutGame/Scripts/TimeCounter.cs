using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float countdown = 90.0f;

    public Text timeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        timeText.text = countdown.ToString("f1") + "";

        if (countdown <= 0)
        {
            timeText.text = "Finish!";
        }
    }
}
