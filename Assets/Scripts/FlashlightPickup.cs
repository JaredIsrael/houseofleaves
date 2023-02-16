using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: TBD
 
 */

public sealed class FlashlightPickup : CompletableTask
{
    [SerializeField] private FlashlightInteractable interactable;
    [SerializeField] PlayerController playerController;

    void Start()
    {
        this.description = "Pick up flashlight";
        TaskCompletedEvent = new UnityEvent<CompletableTask>();
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(CompletePuzzle);
    }

    private void CompletePuzzle()
    {
        TaskCompletedEvent.Invoke(this);
        playerController.hasFlashlight = true;
    }
}
