using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class WorkPuzzle : CompletableTask
{
    [SerializeField]
    private StatuePuzzleInteractable interactable;

    FallTimer fallTimer;

    void Start()
    {
        //To-do: get to appear on the list
        //creates CompleteableTask for the work mini-game
        this.description = "Type up work";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(CompletePuzzle);
        fallTimer.GenerateWord();
    }

    private void CompletePuzzle() {
        TaskCompletedEvent.Invoke(this);
    }

}
