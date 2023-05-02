using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField]
    private Image blackScreen;
    [SerializeField]
    private float FADE_TIME;
    private static bool hasFaded = false;

    void Start()
    {
        if(!hasFaded) StartCoroutine(FadeInFromBlack()); 
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutToBlackAndSwitchScene());
    }

    private IEnumerator FadeInFromBlack()
    {
        hasFaded = true;
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

    private IEnumerator FadeOutToBlackAndSwitchScene()
    {

        blackScreen.gameObject.SetActive(true);
        float startTime = Time.time;
        while (Time.time - startTime < FADE_TIME)
        {
            Color screenColor = blackScreen.color;
            screenColor.a = ((Time.time - startTime) / FADE_TIME);
            blackScreen.color = screenColor;
            yield return null;
        }
        QuickLoader.Instance.QuickLoadSceneAsync("Day3House");

    }

}
