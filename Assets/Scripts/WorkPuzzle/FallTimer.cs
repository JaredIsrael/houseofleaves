using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class tracks the rate in which the words are being spawned to the screen.
 * As time passes, the rate at which words are spawned continues to speed up. 
 */

public class FallTimer : MonoBehaviour
{
    public WorkManager workManager;

    //time between the spawning of each word
    private float delay = 2f;
    private float nextTime = 0f;

    //boolean tracks whether or not the user has lost the game 
    public static bool stop;

    public static string[] passage;

    private void Start()
    {
        stop = false;
        passage = PassageGenerator.GetRandomPassage();
    }

    private void Update()
    {
        if (Time.time >= nextTime && !stop)
        {
            workManager.NewWord(passage);
            nextTime = Time.time + delay;
            delay *= .99f;
        }

        //TO-DO: one passage per session. Instead, level up, then game is complete.
        //Store the current level so the player can start next level on the next day. 
        if (PassageGenerator.levelUp)
        { //player has completed level, choose another passage to type
            passage = PassageGenerator.GetRandomPassage();
            PassageGenerator.levelUp = false;
        }
    }

    //TO-DO: turn update into coroutine
    /*
    public IEnumerator GenerateWord()
    {
        while (true)
        {
            if (!stop)
            {
                workManager.NewWord(passage);
                Debug.Log("New word");
                delay *= .99f;
                yield return new WaitForSecondsRealtime(delay);
            }
        }
    }
    */
}
