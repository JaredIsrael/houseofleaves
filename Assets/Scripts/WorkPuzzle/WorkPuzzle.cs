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

    [SerializeField]
    public int day;

    public Coroutine wordFall;
    public Coroutine input;
    public Coroutine progress;

    public static bool gameOver;
    public static int level;

    void Start()
    {
        //creates CompleteableTask for the work mini-game
        this.description = "Type up work";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(BeginPuzzle);
        level = day;
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

        progress = StartCoroutine(GameObject.Find("Slider").GetComponent<ProgressHandler>().StartProgress());
    }


    public void GameOver()
    {

        StopCoroutine(wordFall);
        StopCoroutine(progress);

        workCanvas.SetActive(false);
        WorkManager.wordIsActive = false;

        im.inputActions.Enable();
        InputManager.UIActions.Enable();
        TaskCompletedEvent.Invoke(this);

    }

}