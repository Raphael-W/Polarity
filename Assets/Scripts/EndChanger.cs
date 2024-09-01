using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChanger : MonoBehaviour
{
    public LevelChanger level_script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Home_fade()
    {
        level_script.Home();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 5f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
