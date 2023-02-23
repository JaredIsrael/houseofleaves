using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: This is an event manager for the first day. This manager will do things
like display dialog or ... that isn't linked to other managers. Generally any
narrative driven event.

Author: Jared Israel

 */

public class Day1Manager: MonoBehaviour
{
    [SerializeField]
    private BinaryQuestionLines WakeUpQuestion;
    [SerializeField]
    private MonologLines monoLines;
    [SerializeField]
    private BinaryQuestionLines questions2;
    //public DialogSet dia
    // Start is called before the first frame update
    void Start()
    {
        DialogManager.Instance.SlowDisplayBinaryQuestionLines(WakeUpQuestion, OnLeft, OnRight);
    }

    public void OnLeft()
    {
        DialogManager.Instance.DisplayMonologLines(monoLines);
    }
    public void OnRight()
    {
        DialogManager.Instance.SlowDisplayBinaryQuestionLines(questions2, OnLeftNoOp, OnRightNoOp);
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
