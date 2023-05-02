using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: This is a final implementation of an objects that can be picked up with
a sphere collider. This is a puzzle object that is used for the wall puzzle.
This is very simple and all it does when it is interacted with is dissapears
and lets everyone know it has been interacted with by invoking an event

Author: Jared Israel

 */

public sealed class KeyInteractable : PickUpSphere
{
    public override void InteractWith()
    {
        InteractedWith.Invoke();
        this.gameObject.SetActive(false);
    }
}
