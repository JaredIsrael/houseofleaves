using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: This abstract class defines the events that all interactable objects
should call through their life, as well providing a public method to attempt
interaction. Any item that will be interacted with (not just pickups) should
inherit from this and be sure to invoke the events when appropriate.

Having events for interaction and the ability to interact with lets us do
things like displaying text or playing audio. It also lets us do things like
dynamic events (enemies come around the corner when you get close to a window)

Author: Jared Israel

 */

public abstract class Interactable : MonoBehaviour
{
    public UnityEvent CanInteractEnterEvent;
    public UnityEvent CanInteractExitEvent;
    public UnityEvent InteractedWith;

    public abstract void InteractWith();

}
