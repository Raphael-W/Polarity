using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private string levelToLoad;

    // Update is called once per frame
    public void StartGame()
    {
        FadeToLevel("Level 6");
    }

    public void End()
    {
        FadeToLevel("End");
    }

    public void Home()
    {
        FadeToLevel("Home");
    }


    public void FadeToLevel(string levelname)
    {
        levelToLoad = levelname;
        animator.SetTrigger("FadeOut"); 
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);  
    }

    public void Levels()
    {
        FadeToLevel("Levels");
    }
}

 