using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitInteractable : PickUpSphere
{

    [SerializeField]
    private float FADE_TIME = 3.5f;
    [SerializeField]
    private Image blackScreen;

    public override void InteractWith()
    {
        StartCoroutine(FadeOutToBlack());
    }

    private IEnumerator FadeOutToBlack()
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

        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MenuScene");

    }
}
