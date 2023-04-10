using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightOneManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        StartCoroutine(StartAmbientMusic());
    }

    private IEnumerator StartAmbientMusic()
    {
        double offset = 0.01;
        double length = audioSources[0].clip.length;
        double time = AudioSettings.dspTime - offset;
        audioSources[index].Play();

        while (true)
        {
            yield return new WaitForSecondsRealtime((float)length);
            time += length;
            index = (index + 1) % audioSources.Length;
            audioSources[index].PlayScheduled(time);
        }
    }
}
