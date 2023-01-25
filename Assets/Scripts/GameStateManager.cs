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
}
