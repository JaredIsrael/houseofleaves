using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDayManager : MonoBehaviour
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
       // DialogManager.Instance.DisplayBinaryQuestionLines(WakeUpQuestion, OnLeft, OnRight);
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
