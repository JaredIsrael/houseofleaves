using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*

Purpose: This is an event manager for the first day. This manager will do things
like display dialog or ... that isn't linked to other managers. Generally any
narrative driven event.

Author: Jared Israel

 */

public class Day4Manager : MonoBehaviour
{
    [SerializeField]
    private MonologLines OpeningLines;
    [SerializeField]
    private Image blackScreen;
    private float FADE_TIME = 3.5f;
    [SerializeField]
    private SleepInteractable4 si;
    [SerializeField]
    private MonologLines sleepLines;

    //public DialogSet dia
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInFromBlackIntroDialog());
        ObjectivesManager.AllTasksCompletedEvent.AddListener(EnableSleep);
    }

    private IEnumerator FadeInFromBlackIntroDialog()
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
        DialogManager.Instance.DisplayMonologLines(OpeningLines);

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
        QuickLoader.Instance.QuickLoadSceneAsync("Maze");

    }

    public void EnableSleep()
    {
        Debug.Log("Displaying sleep lines");
        si.EnableSleep();
        StartCoroutine(SleepLinesDelay());
    }

    private IEnumerator SleepLinesDelay()
    {
        yield return new WaitForSeconds(0.75f);
        DialogManager.Instance.DisplayMonologLines(sleepLines);
    }

    public void GoToNight1()
    {
        StartCoroutine(FadeOutToBlackAndSwitchScene());
    }
}
