using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class tracks the rate in which the words are being spawned to the screen.
 * As time passes, the rate at which words are spawned continues to speed up. 
 */

public class FallTimer : MonoBehaviour
{
    [SerializeField] public WorkManager workManager;
    [SerializeField] public float speed;

    //time between the spawning of each word
    public static float delay;
    public static float nextTime = 0f;

    //boolean tracks whether or not the user has lost the game 
    public static bool stop;

    public static string[] passage;

    private void Start()
    {
        delay = speed;
        stop = false;
        passage = PassageGenerator.GetPassage();
    }

    //turned first part of update into coroutine
    public IEnumerator GenerateWord()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if(Time.time >= nextTime && !stop)
            {
                workManager.NewWord(passage);
                nextTime = Time.time + delay;
                delay *= .999f;
            }
        }
    }
   
}
