using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 
Purpose: This script controls and maintains the state of the game, that is,
whether the game is play or pause mode, quitting, stuff like that. Not related
to mechanics.

Author: 

 */

public class GameStateManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject pauseScreen;

    public bool usingPause = false;
    public bool previousPauseInput = false;

    void Start()
    {
        pauseScreen.SetActive(false);
    }

    public void ReadPauseInput(bool paused, bool exit)
    {
        if(!previousPauseInput && paused)
        {
            usingPause = !usingPause;
            pauseScreen.SetActive(usingPause);
        }

        if(usingPause)
        {
            player.DisableMovement();
            player.LockCamera();

            if (exit)
            { //user clicks Q to quit game
                ReadExitInput();
            }
        }
        else
        {
            player.EnableMovement();
            player.UnlockCamera();
        }

        previousPauseInput = paused;
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
