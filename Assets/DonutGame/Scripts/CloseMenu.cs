using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    public GameObject blackui;
    public semanager2 SEmanager2;
    void Start()
    {
        blackui.SetActive(false);
    }

    public void OnCloseMenu(){
        SEmanager2.closeMenuSEmanager();
        blackui.SetActive(false);
    }
}
