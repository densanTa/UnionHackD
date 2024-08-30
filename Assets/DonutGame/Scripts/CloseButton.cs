using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject backui;
    // Start is called before the first frame update
    void Start()
    {
        backui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclose(){
        backui.SetActive(false);
    }
}
