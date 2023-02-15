using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: This is the PickUpSphere component for starting the Laundry puzzle. This
handles the interaction portion of the laundry puzzle, when the InteractedWith
event is invoked, the puzzle will begin

Author: Jared Israel

 */

public class LaundryPuzzleInteractable : PickUpSphere
{
    [SerializeField]
    private PlayerController pc;
    [SerializeField]
    private Transform puzzlePlayerPos;
    [SerializeField]
    private Transform puzzleCameraPos;
    [SerializeField]
    private const float TRANSITION_DURATION = 1f;
    private Vector3 initialPos;
    private bool hasBeenInteractedWith = false;

    public override void InteractWith()
    {
        //TODO: Move this to LaundryPuzzle.cs
        if (!hasBeenInteractedWith)
        {
            hasBeenInteractedWith = true;
            initialPos = pc.gameObject.transform.position;
            pc.DisableMovement();
            pc.LockCamera();
            //StartCoroutine(MovePlayerToPosition(pc.gameObject, pc.cam));
            pc.MovePlayerToPointWithLook(puzzlePlayerPos, puzzleCameraPos, TRANSITION_DURATION);
            this.InteractedWith.Invoke();
        }

    }

    //TODO: Move this to LaundryPuzzle.cs
    public void MoveBackToInitialPosition()
    {
        pc.MovePlayerToPoint(initialPos, TRANSITION_DURATION);
        pc.EnableMovement();
        pc.UnLockCamera();
    }
}
