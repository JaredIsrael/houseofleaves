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
    private float delay = 1f;
    private float nextTime = 0f;

    //boolean tracks whether or not the user has lost the game 
    public static bool stop;

    private string[] passage;

    private void Start()
    {
        stop = false;
        passage = PassageGenerator.GetRandomPassage();
    }

    private void Update()
    {
        /*
        if (Time.time >= nextTime && !stop)
        {
            workManager.NewWord(passage);
            nextTime = Time.time + delay;
            delay *= .99f;
        }
        */
        if (PassageGenerator.levelUp)
        { //player has completed level, choose another passage to type
            passage = PassageGenerator.GetRandomPassage();
            PassageGenerator.levelUp = false;
        }
    }

    public void StartWork()
    {
        StartCoroutine(GenerateWord());
    }

    public IEnumerator GenerateWord()
    {
        if (Time.time >= nextTime && !stop)
        {
            workManager.NewWord(passage);
            nextTime = Time.time + delay;
            delay *= .99f;
        }
        yield return null;
    }
}
