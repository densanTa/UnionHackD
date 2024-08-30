using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject backui;
    public semanager1 SEmanager1;
    // Start is called before the first frame update
    void Start()
    {
        backui.SetActive(false);
    }

   

    public void Onclose(){
        SEmanager1.closeSemanager();
        backui.SetActive(false);
    }

    
}
