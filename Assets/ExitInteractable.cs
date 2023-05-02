using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ExitInteractable : PickUpSphere
{

    [SerializeField]
    private float FADE_TIME = 3.5f;
    [SerializeField]
    private Image blackScreen;
    [SerializeField]
    private TextMeshProUGUI text;

    public override void InteractWith()
    {
        StartCoroutine(FadeOutToBlack());
    }

    private IEnumerator FadeOutToBlack()
    {

        blackScreen.gameObject.transform.parent.gameObject.SetActive(true);
        float startTime = Time.time;
        while (Time.time - startTime < FADE_TIME)
        {
            Color screenColor = blackScreen.color;
            screenColor.a = ((Time.time - startTime) / FADE_TIME);
            text.alpha = ((Time.time - startTime) / FADE_TIME);
            blackScreen.color = screenColor;
            yield return null;
        }

        StartCoroutine(End());


    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("MenuScene");

    }
}
