using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: This class is a final implementaiton of the CompletableTask class that
represents the wall statue puzzle. It needs to keep track of an interactable
made for this puzzle and the room manipulator
 
 */

public sealed class StatuePuzzle : CompletableTask
{
    [SerializeField]
    private StatuePuzzleInteractable interactable;
    [SerializeField]
    private RoomManipulator rm;

    private bool hasMoved = false;

    void Start()
    {
        TaskCompletedEvent = new UnityEvent();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(CompletePuzzle);
    }

    private void CompletePuzzle()
    {
        if (!hasMoved)
        {
            rm.Move();
            hasMoved = true;
        }
        // TODO: I don't like this, get objectives manager to listen to the event instead
        ObjectivesManager.Instance.CompleteObjective(this);
        
    }
}
