using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;
using UnityEngine;

public class character_controller : MonoBehaviour
{
    
    Vector3 magnetpos;
    Vector3 end_pos;
    GameObject end;
    Rigidbody2D rb;
    string magnetname;
    GameObject magnet;
    bool stop;
    Vector2 spawn_pos;
    GameObject Spawn;
    float magnet_y;
    float current_y;
    public Material[] material;
    public int x;
    Renderer Rend;
    public float Border_y;
    public float my_y;
    public bool completed;
    public Collider coll;
    GameObject compass;
    float speed;
    float MaxSpeed;
    float Acceleration;
    float Deceleration;
    float start;
    float cur_speed;
    GameObject original_spawn;
    Vector2 original_pos;
    public string spawn_dir;
    public LevelChanger level_script;
    public ebbing_pole pol_script;
    public bool repelling;
    public float error_speed;

    void Start()
    {
        MaxSpeed = 3f;
        Acceleration = 3;
        Deceleration = 3f;
        x = 0;
        Rend = GetComponent<Renderer>();
        Rend.enabled = true;
        Rend.sharedMaterial = material[x];
        rb = GetComponent<Rigidbody2D>();
        spawn_pos = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        original_pos = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        transform.position = spawn_pos;
        Spawn = GameObject.FindGameObjectWithTag("Spawn");
        Spawn.SetActive(false);
        Border_y = GameObject.FindGameObjectWithTag("Border").transform.position.y;
        Physics2D.gravity = new Vector2(0.0f, -9.8f);
        compass = GameObject.FindGameObjectWithTag("Compass");
        speed = 3;
        start = 0.1f;
        cur_speed = 0f;
        stop = false;
        repelling = false;
        spawn_dir = "Right";
        
    }


    public void End_fade()
    {
        level_script.End();
    }


    void Update()
    {
        error_speed = rb.velocity.x;
        if (error_speed > 0.1f || error_speed < -0.1f)
        {
            rb.velocity = Vector2.zero;
        }

        if (stop == false && Input.GetKey(KeyCode.Space))
        { 
            if (speed < 0 && cur_speed > speed)
            {
                cur_speed = cur_speed - Acceleration * Time.deltaTime;
            }

            else if (speed > 0 && cur_speed < speed)
            {
                cur_speed = cur_speed + Acceleration * Time.deltaTime;
            }

        }

        else
        {
            if (speed < 0 && cur_speed < 0)
            {
                cur_speed = cur_speed + Deceleration * Time.deltaTime;
            }

            else if (speed > 0 && cur_speed > 0)
            {
                cur_speed = cur_speed - Deceleration * Time.deltaTime;
            }

            else
            {
                cur_speed = 0;
            }
        }


        transform.Translate(cur_speed * Time.deltaTime, 0, 0);

        Border_y = GameObject.FindGameObjectWithTag("Border").transform.position.y;
        Rend.sharedMaterial = material[x];
        my_y = (rb.transform.position.y);


        if (Input.GetKey(KeyCode.R))
        {
            Respawn();
        }

        else
        {
            stop = false;
        }

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

        if (Border_y > my_y)
        {
            stop = true;
            if (completed == false)
            {
                StartCoroutine(Death_Respawn());
            }
        }
    }

    public IEnumerator EndScene ()
    {
        yield return new WaitForSeconds(0.5f);
        //SceneManager.LoadScene("End");
        SceneManager.LoadScene("End");
    }

    
    public void Respawn()
    {
        completed = true;
        speed = 3f;
        transform.position = original_pos;
        spawn_pos = original_pos;
        stop = false;
        completed = false;
        cur_speed = 0f;
        Physics2D.gravity = new Vector2(0.0f, -9.8f);
        //rb.velocity = Vector2.zero;
    }

    public IEnumerator Death_Respawn()
    {
        completed = true;
        yield return new WaitForSeconds(2f);
        transform.position = spawn_pos;
        Physics2D.gravity = new Vector2(0.0f, -9.8f);
        //rb.velocity = Vector2.zero;
        if (spawn_dir == "Right")
        {
            speed = 3f;
        }

        else if (spawn_dir == "Left")
        {
            speed = -3;
        }
        
        yield return new WaitForSeconds(1.5f);
        stop = false;
        completed = false;
        cur_speed = 0f;
    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "SouthMagnet")
        {
            magnetname = col.gameObject.name;
            magnetpos = GameObject.Find(magnetname).transform.position;

            if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
            {
                stop = true;
                Vector3 newPosition = Vector3.MoveTowards(transform.position, magnetpos, 0.3f);
                transform.position = newPosition;
                Physics2D.gravity = Vector2.zero;
            }

            else if (Input.GetMouseButton(1))
            {
                Physics2D.gravity = new Vector2(0.0f, -9.8f);
                magnet = GameObject.Find(magnetname);
                magnet_y = (magnet.transform.position.y) - 0.3f;
                current_y = (rb.transform.position.y);
                if (current_y >= magnet_y && repelling == false)
                {
                    if (compass.transform.rotation.eulerAngles.z < 360 && compass.transform.rotation.eulerAngles.z > 180)
                    {
                        speed = 3f;
                        cur_speed = 3f;
                    }

                    else if (compass.transform.rotation.eulerAngles.z > 0 && compass.transform.rotation.eulerAngles.z < 180)
                    {
                        speed = -3f;
                        cur_speed = -3f;
                    }

                    //rb.velocity = Vector2.zero;
                    rb.velocity = Vector2.up * ((pol_script.cur_size)*2);
                    repelling = true;
                    

                }
                
            }

            else
            {
                Physics2D.gravity = new Vector2(0.0f, -9.8f);
            }


        }

        else
        {
            repelling = false;
        }

        if (col.gameObject.tag == "NorthMagnet")
        {
            magnetname = col.gameObject.name;
            magnetpos = GameObject.Find(magnetname).transform.position;

            if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
            {
                stop = true;
                Vector3 newPosition = Vector3.MoveTowards(transform.position, magnetpos, 0.5f);
                transform.position = newPosition;
                Physics2D.gravity = Vector2.zero;
            }

            else if (Input.GetMouseButton(0))
            {
                Physics2D.gravity = new Vector2(0.0f, -9.8f);
                magnet = GameObject.Find(magnetname);
                magnet_y = (magnet.transform.position.y) - 0.3f;
                current_y = (rb.transform.position.y);
                if (current_y >= magnet_y && repelling == false)
                {
                    if (compass.transform.rotation.eulerAngles.z < 360 && compass.transform.rotation.eulerAngles.z > 180)
                    {
                        speed = 3f;
                        cur_speed = 3;
                    }

                    else if (compass.transform.rotation.eulerAngles.z > 0 && compass.transform.rotation.eulerAngles.z < 180)
                    {
                        speed = -3f;
                        cur_speed = -3;
                    }

                    //rb.velocity = Vector2.zero;
                    rb.velocity = Vector2.up * ((pol_script.cur_size) * 2);
                    repelling = true;
                    
                }

            }

            else
            {
                Physics2D.gravity = new Vector2(0.0f, -9.8f);
            }


        }

        else
        {
            repelling = false;
        }

        if (col.gameObject.tag == "End")
        {
            end_pos = col.gameObject.transform.position;
            stop = true;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, end_pos, 0.3f);
            transform.position = newPosition;
            Physics2D.gravity = Vector2.zero;
        }

        else
        {
            rb.gravityScale = 1.0f;
        }

        if (col.gameObject.tag == "Platform")
        {
            stop = true;
        }

        if (col.gameObject.tag == "NextLevel")
        {
            StartCoroutine(EndScene());
        }

        if (col.gameObject.tag == "Right Checkpoint")
        {
            spawn_pos = col.gameObject.transform.position;
            spawn_dir = "Right";
        }


        if (col.gameObject.tag == "Left Checkpoint")
        {
            spawn_pos = col.gameObject.transform.position;
            spawn_dir = "Left";
        }

    }

}