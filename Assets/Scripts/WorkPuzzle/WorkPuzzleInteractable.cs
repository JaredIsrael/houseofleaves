using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPuzzleInteractable : PickUpSphere
{
    public override void InteractWith()
    {
        InteractedWith.Invoke();
    }
}
