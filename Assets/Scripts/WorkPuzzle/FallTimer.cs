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
    public float delay = 1.5f;
    private float nextTime = 0f;

    private string[] passage;

    private void Start()
    {
        passage = PassageGenerator.GetRandomPassage();
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            workManager.NewWord(passage);
            nextTime = Time.time + delay;
            delay *= .99f;
        }
    }
}
