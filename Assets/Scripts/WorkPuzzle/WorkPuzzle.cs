using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public sealed class WorkPuzzle : CompletableTask
{
    [SerializeField]
    private StatuePuzzleInteractable interactable;

    [SerializeField]
    private GameObject workCanvas;

    FallTimer fallTimer;
    WorkInput workInput;

    void Start()
    {
        //creates CompleteableTask for the work mini-game
        this.description = "Type up work";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(BeginPuzzle);
        //workCanvas.SetActive(false);
    }

    void BeginPuzzle()
    {

        Debug.Log("WORK WORK WORK");

        //workCanvas.SetActive(true);
        //starts the coroutine GenerateWord(), words begin falling
        //StartCoroutine(GameObject.Find("WorkManager").GetComponent<FallTimer>().GenerateWord());

        //does this belong here? starts the coroutine that tracks the input user
        //is typing. or can it be put within the generate word coroutine maybe?
        //StartCoroutine(GameObject.Find("WorkManager").GetComponent<WorkInput>().KeyTracking());
    }

}