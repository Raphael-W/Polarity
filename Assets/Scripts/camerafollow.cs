using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 velocity = Vector3.zero;
    GameObject Border;
    public float Border_y;
    public float current_y;
    GameObject Player;
    public float Player_x;
    public float Player_y;
    public Vector3 go_to;
    public Vector3 desiredPosition;
    GameObject player;
    Vector2 player_pos;

    void Start()
    {

        Border = GameObject.FindGameObjectWithTag("Border");
        Border_y = GameObject.FindGameObjectWithTag("Border").transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
        player_pos = player.transform.position;
        transform.position = player_pos;// + new Vector2(0, 10);

        //Border.SetActive(false);

    }

    void Update()
    {
        current_y = transform.position.y;
        Player = GameObject.FindGameObjectWithTag("Player");
        Player_x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        Player_y = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        go_to = new Vector3(Player_x, Border_y, 0f);
    }
    
    void LateUpdate ()
    {
        if ((Border_y + 1f) < Player_y)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
            //Debug.Log("Normal");
        }

        else if ((Border_y + 1f) > Player_y)
        {
            Vector3 desiredPosition = go_to + offset;
            //Debug.Log("Dead");
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }


        //Vector3 desiredPosition = target.position + offset;
        

        
        
    }
}
