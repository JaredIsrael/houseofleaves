using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class ThrowableObject : CompletableTask
{
    [SerializeField] private StatuePuzzleInteractable interactable;
    [SerializeField] PlayerController playerController;

    bool oneObjectAdded = false;

    void Start()
    {
        //this.description = "Pick up throwable object";
        //TaskCompletedEvent = new UnityEvent<CompletableTask>();
        //ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(CompletePuzzle);
    }

    private void CompletePuzzle()
    {
        if(!oneObjectAdded)
        {
            playerController.throwableObjects++;
            oneObjectAdded = true;
        }
        //TaskCompletedEvent.Invoke(this);
    }
}
