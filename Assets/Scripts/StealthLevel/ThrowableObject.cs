using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: TBD
 
 */

public sealed class ThrowableObject : CompletableTask
{
    [SerializeField] private ThrowableObjectInteractable interactable;
    [SerializeField] PlayerController playerController;

    bool oneObjectAdded = false;

    void Start()
    {
        interactable.InteractedWith.AddListener(ObjectPickUp);
    }

    private void ObjectPickUp()
    {
        if(!oneObjectAdded)
        {
            Debug.Log("Object Added");
            playerController.throwableObjects++;
            oneObjectAdded = true;
        }
    }
}