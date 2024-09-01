using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    bool isPaused = false;
    public AudioMixer audioMixer;
    public Camera gameCamera;
    public Slider FOVSlider;
    GameObject spawn;
    GameObject player;
    Vector2 spawn_pos;
    public character_controller player_script;
    public LevelChanger level_script;

    private void Start()
    {
        FOVSlider.value = 5f;
        spawn = GameObject.FindGameObjectWithTag("Spawn");
        player = GameObject.FindGameObjectWithTag("Player");
        spawn_pos = spawn.transform.position;
    }

    public void Home_fade()
    {
        level_script.Home();
    }

    public void level_fade()
    {
        level_script.Levels();
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    
    public void BeginGane()
    {
        level_script.StartGame();
    }
    
    public void Restart()
    {
        player_script.Respawn();
        post_restart();
    }
    
    public void SetFOV(float FOV)
    {
        gameCamera.orthographicSize = FOV;
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    public void pauseGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1;
            isPaused = false;
        }

        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void start()
    {
        Time.timeScale = 1f;
    }

    public void post_restart()
    {
        Time.timeScale = 1;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Levels");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 6");
    }

    public void instr1()
    {
        SceneManager.LoadScene("Instr. 0");
    }

    public void instr2()
    {
        SceneManager.LoadScene("Instr. 2");
    }

    public void instr3()
    {
        SceneManager.LoadScene("Instr. 3");
    }

    public void instr4()
    {
        SceneManager.LoadScene("Instr. 4");
    }

    public void instr5()
    {
        SceneManager.LoadScene("Instr. 5");
    }

    public void trainingbox()
    {
        SceneManager.LoadScene("Training Box");
    }

    public void ForwardScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackwardScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instr. 0");
    }

}
