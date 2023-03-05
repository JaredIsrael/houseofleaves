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

    public static Coroutine wordFall;

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

        //TO-DO: Disable input/UI actions for player movement while game is active
        InputManager.inputActions.Disable();
       
        //set the canvas of the work game active
        workCanvas.SetActive(true);

        //starts the coroutine GenerateWord(), game starts as words begin falling
        wordFall = StartCoroutine(GameObject.Find("WorkManager").GetComponent<FallTimer>().GenerateWord());

        //starts the coroutine that tracks the input user is typing
        //StartCoroutine(GameObject.Find("WorkManager").GetComponent<WorkInput>().KeyTracking());
    }

    

}