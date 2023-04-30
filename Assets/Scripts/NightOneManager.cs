using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightOneManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    private int index;
    [SerializeField]
    private Image blackScreen;
    private float FADE_TIME = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        StartCoroutine(FadeInFromBlack());
        StartCoroutine(StartAmbientMusic());
    }

    private IEnumerator FadeInFromBlack()
    {
        blackScreen.gameObject.SetActive(true);
        float startTime = Time.time;
        while (Time.time - startTime < FADE_TIME)
        {
            Color screenColor = blackScreen.color;
            screenColor.a = 1 - ((Time.time - startTime) / FADE_TIME);
            blackScreen.color = screenColor;
            yield return null;
        }
        blackScreen.gameObject.SetActive(false);

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
