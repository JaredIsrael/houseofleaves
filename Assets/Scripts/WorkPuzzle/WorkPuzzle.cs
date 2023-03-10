using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public sealed class WorkPuzzle : CompletableTask
{
    [SerializeField]
    private WorkPuzzleInteractable interactable;
    [SerializeField]
    private InputManager im;

    [SerializeField]
    private GameObject workCanvas;

    [SerializeField]
    private GameObject loseText;

    public Coroutine wordFall;
    public Coroutine input;

    public static bool gameOver;

    void Start()
    {
        //creates CompleteableTask for the work mini-game
        this.description = "Type up work";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(BeginPuzzle);
    }

    void BeginPuzzle()
    {
        //TO-DO: enable/disable the UI input actions
        im.inputActions.Disable();
        InputManager.UIActions.Disable();
       
        //set the canvas of the work game active
        workCanvas.SetActive(true);
        loseText.SetActive(false);

        //set all necessary variables
        FallTimer.stop = false; 
        FallTimer.delay = 1f;
        FallTimer.nextTime = 0f;
        gameOver = false;

        //starts the coroutine GenerateWord(), game starts as words begin falling
        wordFall = StartCoroutine(GameObject.Find("WorkManager").GetComponent<FallTimer>().GenerateWord());

        //starts the coroutine that tracks the input user is typing
        //input = StartCoroutine(GameObject.Find("WorkManager").GetComponent<WorkInput>().KeyTracking());
    }

    private void Update()
    {
        if (gameOver)
        {//game is complete
            TaskCompletedEvent.Invoke(this);

            StopCoroutine(wordFall);
            //StopCoroutine(input);

            workCanvas.SetActive(false);

            im.inputActions.Enable();
            InputManager.UIActions.Enable();
        }
    }

    

}