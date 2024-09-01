using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ebbing_pole : MonoBehaviour
{
    public float max_size;
    public float min_size;
    public float cur_size;
    public float speed;
    public bool next;
    public bool grow;
    public Light2D playerlight;
    public GameObject pole;
    public col_ebbing_pole ebb_script;



    // Start is called before the first frame update
    void Start()
    {
        min_size = 0.45f;
        max_size = 2.3f;
        speed = 0.01f;
        next = false;
        grow = true;
        playerlight = GetComponent<Light2D>();
        cur_size = ebb_script.cur_size;


    }

    public void random_num(float random)
    {
        cur_size = random;
    }
    
    // Update is called once per frame
    public void ebb(float size)
    {
        if (cur_size > size)
        {
            cur_size -= speed;
        }

        else if (cur_size < size)
        {
            cur_size += speed;
        }

        if (cur_size < (size + 0.1) && cur_size > (size - 0.1))
        {
            next = true;
        }

        playerlight.pointLightOuterRadius = cur_size;
    }
    
    void Update()
    {

        if (next == true)
        {
            if (grow == true)
            {
                grow = false;
                next = false;
            }

            else if (grow == false)
            {
                grow = true;
                next = false;
            }
        }

        if (grow == true)
        {
            ebb(max_size);
        }

        else if (grow == false)
        {
            ebb(min_size);
        }

    }
}
