using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class WorkPuzzle : CompletableTask
{
    void Start()
    {
        //creates CompleteableTask for the work mini-game
        this.description = "Type up work";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
    }

    private void CompletePuzzle() {
        TaskCompletedEvent.Invoke(this);
    }

}
