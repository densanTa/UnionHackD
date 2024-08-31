using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Timecounter_a.score_1= "+Timecounter_a.score_1);
        Debug.Log("Timecounter_b.score_2= "+Timecounter_b.score_2);
        Debug.Log("Timecounter_c.score_3= "+Timecounter_c.score_3);
        Debug.Log("Timecounter_d.score_4= "+Timecounter_d.score_4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
