using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;
using UnityEngine;

public class example_ball : MonoBehaviour
{

    public Material[] material;
    public int x;
    Renderer Rend;
    GameObject compass;

    void Start()
    {
        x = 0;
        Rend = GetComponent<Renderer>();
        Rend.enabled = true;
        Rend.sharedMaterial = material[x];
        compass = GameObject.FindGameObjectWithTag("Compass");

    }



    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            x = 1;
            compass.SetActive(true);
        }


        else if (Input.GetMouseButton(1))
        {
            x = 2;
            compass.SetActive(true);
        }

        else
        {
            x = 0;
            compass.SetActive(false);
        }

        Rend.sharedMaterial = material[x];
    }

}