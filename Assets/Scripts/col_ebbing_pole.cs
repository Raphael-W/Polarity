using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class col_ebbing_pole : MonoBehaviour
{
    public float max_size;
    public float min_size;
    public float cur_size;
    public float speed;
    public bool next;
    public bool grow;
    public CircleCollider2D pole_collider;
    public GameObject light;


    // Start is called before the first frame update
    void Start()
    {
        min_size = 0.45f;
        max_size = 2.3f;
        cur_size = Random.Range(min_size, max_size);
        light.SendMessage("random_num", cur_size);
        speed = 0.01f;
        next = false;
        grow = true;
        pole_collider = GetComponent<CircleCollider2D>();



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


        pole_collider.radius = cur_size;

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
