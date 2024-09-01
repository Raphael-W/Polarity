using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings_toggle : MonoBehaviour
{
    private Canvas CanvasObject;

    void Start()
    {
        CanvasObject = GameObject.Find("Settings_Canvas").GetComponent<Canvas>();
        CanvasObject.GetComponent<Canvas>().enabled = false;
    }

    public void ToggleCanvas()
    {

        Debug.Log(CanvasObject.GetComponent<Canvas>().enabled);
        if (CanvasObject.enabled == true)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
        else
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }

        
    }
}
