using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    private int pauseHits;

    void Start()
    {
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ReadPauseInput(bool paused, bool exit)
    {
        if (paused)
        {
            pauseHits++;
        }
        if (exit)
        { //user clicks Q to quit game
            ReadExitInput();
        }
        if (pauseHits % 2 == 1)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        } else
        {
            if (Time.timeScale != 1)
            {
                Time.timeScale = 1;
            }
            if (pauseScreen.activeInHierarchy == true)
            {
                pauseScreen.SetActive(false);
            }
        }
    }

    public void ReadResetInput(bool reset)
    {
        if (reset)
        {
            SceneManager.UnloadSceneAsync("PlayTestArea");
            SceneManager.LoadSceneAsync("PlayTestArea");
        }
            
    }

    //exit game state
    public void ReadExitInput()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
