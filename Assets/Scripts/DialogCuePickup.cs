using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EZ little pickup that plays whatever dialog it holds :3 AUTHOR: JAMIE DAVENPORT
// Was going to use PickUpSphere, but it's not an "interactible" item. I wanted invisible "cues", which i made a prefab for.

public class DialogCuePickup : MonoBehaviour
{
    [SerializeField] MonologLines dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogManager.Instance.DisplayMonologLines(dialogue);
            Destroy(this);
        }
    }
}
