using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class WorkPuzzle : CompletableTask
{
    [SerializeField]
    private StatuePuzzleInteractable interactable;

    FallTimer fallTimer;
    WorkInput workInput;

    void Start()
    {
        //TO-DO: get to appear on the list
        //creates CompleteableTask for the work mini-game
        this.description = "Type up work";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(StartPuzzle);
    }

    private void StartPuzzle() {
        //starts the coroutine GenerateWord(), words begin falling
        StartCoroutine(fallTimer.GenerateWord());

        //does this belong here? starts the coroutine that tracks the input user
        //is typing. or can it be put within the generate word coroutine maybe?
        StartCoroutine(workInput.KeyTracking());
    }

}
