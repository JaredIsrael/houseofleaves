using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject exitScreen;
    private int pauseHits;

    void Start()
    {
        pauseScreen.SetActive(false);
        exitScreen.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ReadPauseInput(bool paused)
    {
        if (paused)
        {
            pauseHits++;
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
    public void ReadExitInput(bool exit, bool yes, bool no)
    {
        if (exit)
        {
            exitScreen.SetActive(true);

            if (yes)
            { //user selects "Y" to quit game
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
            }
            if (no)
            { //user selects "N" to return to game
                exitScreen.SetActive(false);
            }
        }
    }
}
