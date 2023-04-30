using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVInteractable : PickUpSphere
{
    [SerializeField]
    private MonologLines TVDialog;
    private bool interacted;

    public void Start()
    {
        interacted = false;
    }

    public override void InteractWith()
    {
        if(interacted == false)
        {
            interacted = true;
            DialogManager.Instance.DisplayMonologLines(TVDialog);
        }
    }
}
