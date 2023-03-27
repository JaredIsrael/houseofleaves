using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDayManager : MonoBehaviour
{
    [SerializeField]
    private BinaryQuestionLines WakeUpQuestion;
    [SerializeField]
    private MonologLines monoLines;
    [SerializeField]
    private BinaryQuestionLines questions2;
    [SerializeField]
    private Image blackScreen;
    private float FADE_TIME = 2.5f;
    //public DialogSet dia
    // Start is called before the first frame update
    void Start()
    {
        // DialogManager.Instance.DisplayBinaryQuestionLines(WakeUpQuestion, OnLeft, OnRight);
        StartCoroutine(FadeInFromBlack());
    }

    private IEnumerator FadeInFromBlack()
    {
        bool delayed = false;
        blackScreen.gameObject.SetActive(true);
        float startTime = Time.time;
        while(Time.time-startTime < FADE_TIME)
        {
            //figure this out
            //if (!delayed)
            //{
            //    yield return new WaitForSeconds(1f);
            //    delayed = true;
            //}
            Color screenColor = blackScreen.color;
            screenColor.a = 1-((Time.time - startTime) / FADE_TIME);
            blackScreen.color = screenColor;
            yield return null;
        }
        blackScreen.gameObject.SetActive(false);
    }

    public void OnLeft()
    {
        DialogManager.Instance.DisplayMonologLines(monoLines);
    }
    public void OnRight()
    {
        DialogManager.Instance.DisplayBinaryQuestionLines(questions2, OnLeftNoOp, OnRightNoOp);
    }

    public void OnLeftNoOp()
    {
        Debug.Log("Left was clicked!");
    }

    public void OnRightNoOp()
    {
        Debug.Log("Right was clicked!");
    }
}
