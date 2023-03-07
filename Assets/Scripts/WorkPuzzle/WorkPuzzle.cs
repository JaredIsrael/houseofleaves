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

    public Coroutine wordFall;
    public Coroutine input;

    public static bool gameOver;

    void Start()
    {
        //creates CompleteableTask for the work mini-game
        gameOver = false;
        this.description = "Type up work";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(BeginPuzzle);
    }

    void BeginPuzzle()
    {
        //TO-DO: enable/disable the UI input actions
        InputManager.inputActions.Disable();
        InputManager.UIActions.Disable();
       
        //set the canvas of the work game active
        workCanvas.SetActive(true);

        //starts the coroutine GenerateWord(), game starts as words begin falling
        wordFall = StartCoroutine(GameObject.Find("WorkManager").GetComponent<FallTimer>().GenerateWord());

        //starts the coroutine that tracks the input user is typing
        input = StartCoroutine(GameObject.Find("WorkManager").GetComponent<WorkInput>().KeyTracking());
    }

    private void Update()
    {
        if (gameOver)
        {//game is complete
            TaskCompletedEvent.Invoke(this);
            StopCoroutine(wordFall);
            StopCoroutine(input);
            workCanvas.SetActive(false);
            InputManager.inputActions.Enable();
            InputManager.UIActions.Enable();
        }
    }

    

}