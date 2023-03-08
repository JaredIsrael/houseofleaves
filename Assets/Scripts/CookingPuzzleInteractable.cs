using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: This is the PickUpSphere component for starting the cooking puzzle. This
handles the interaction portion of the cooking puzzle, when the InteractedWith
event is invoked, the puzzle will begin

Author: Jared Israel

 */

public class CookingPuzzleInteractable : PickUpSphere
{
    private bool interactedWith = false;
    public override void InteractWith()
    {
        if (!interactedWith)
        {
            Debug.Log("Puzzle interacte");
            InteractedWith.Invoke();
            interactedWith = true;
        }
    }
}
