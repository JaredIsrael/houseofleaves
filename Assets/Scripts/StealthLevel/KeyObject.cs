using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: TBD
 
 */

public sealed class KeyObject : CompletableTask
{
    [SerializeField] private KeyInteractable interactable;
    [SerializeField] PlayerController playerController;

    bool keyPickedUp = false;

    void Start()
    {
        interactable.InteractedWith.AddListener(ObjectPickUp);
    }

    private void ObjectPickUp()
    {
        if (!keyPickedUp)
        {
            Debug.Log("Level Key Collected");
            keyPickedUp = true;
        }
    }
}
