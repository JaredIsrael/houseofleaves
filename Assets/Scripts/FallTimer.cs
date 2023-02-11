using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTimer : MonoBehaviour
{
    public WorkManager workManager;

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
