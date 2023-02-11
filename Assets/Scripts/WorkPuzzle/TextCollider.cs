using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider : MonoBehaviour
{
    GameObject[] words;

    private void Update()
    {
        //if a word escapes the screen, stop game.
        words = GameObject.FindGameObjectsWithTag("Word");
        foreach (GameObject word in words)
        {
            if (word.transform.position.y < -45)
            {
                LostGame();
            }
        }
    }

    public void LostGame()
    {
        Time.timeScale = 0;

    }

}
