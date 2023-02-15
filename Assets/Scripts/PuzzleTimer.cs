using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*

Purpose: This is a simple script that handles the timing of a puzzle and
updating the UI for a timer, emits an event when complete

Author: Jared Israel
 
 */

public class PuzzleTimer : MonoBehaviour
{
    [SerializeField]
    private Image bar;
    public UnityEvent TimeRanOutEvent;
    private float duration = 0f;
    private void Awake()
    {
        TimeRanOutEvent = new UnityEvent();
        bar.transform.parent.gameObject.SetActive(false);
    }

    public void startTimer(float duration)
    {
        this.duration = duration;
        bar.transform.parent.gameObject.SetActive(true);
        StartCoroutine(BeginCountDown());
    }

    public void DisableTimer()
    {
        StopAllCoroutines();
        bar.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator BeginCountDown()
    {
        float currentTime = Time.time;
        float goalTime = currentTime + duration;
        while(currentTime < goalTime)
        {
            currentTime = Time.time;
            float progress = (goalTime - currentTime) / duration;
            bar.fillAmount = progress;
            yield return null;
        }
        TimeRanOutEvent.Invoke();
    }

}
