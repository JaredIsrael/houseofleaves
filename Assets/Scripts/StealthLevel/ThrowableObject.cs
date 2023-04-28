using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: TBD
 
 */

public sealed class ThrowableObject : CompletableTask
{
    [SerializeField] private ThrowableObjectInteractable[] interactables;
    [SerializeField] PlayerController playerController;

    bool oneObjectAdded = false;

    void Start()
    {
        for(int i = 0; i < interactables.Length; i++)
        {
            interactables[i].InteractedWith.AddListener(ObjectPickUp);
        }
    }

    private void ObjectPickUp()
    {
        if(!oneObjectAdded)
        {
            playerController.throwableObjects++;
            oneObjectAdded = true;
        }
    }
}