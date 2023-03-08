using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: This is an abstract implementation of the interactable class that
represents an object that can be picked up with a mesh collider. All objects
matching this description should implement this in order to minimize code
duplication and allow compatability with pickup controller.

Actual pickup is handled by the pickup controller class, this simply lets the
controller know when it is in range to be picked up and when it leaves.

This approach abstracts away the details of pickup mechanics from the actual
event of pickup, which is preset in the final class that implements InteractWith()

Author Jared Israel
 
 */

public abstract class PickUpFlashlight : Interactable
{
    // Start is called before the first frame update

    void Awake()
    {
        CanInteractEnterEvent = new UnityEvent();
        CanInteractExitEvent = new UnityEvent();
        InteractedWith = new UnityEvent();

        CanInteractEnterEvent.AddListener(AddToInteractList);
        CanInteractExitEvent.AddListener(RemoveFromInteractList);

        if (GetComponent<MeshCollider>() == null)
        {
            Debug.Log("No collider detected on flashlight pickup!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CanInteractEnterEvent.Invoke();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CanInteractExitEvent.Invoke();
        }
    }

    public void AddToInteractList()
    {
        PickUpController.Instance.AddToPickUpList(this);
    }

    public void RemoveFromInteractList()
    {
        PickUpController.Instance.RemoveFromPickupList(this);
    }

}
