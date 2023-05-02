using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepInteractable2 : PickUpSphere
{

    [SerializeField]
    private Day2Manager dm;
    private bool isEnabled;

    private void Start()
    {
        isEnabled = false;
    }

    public void EnableSleep()
    {
        isEnabled = true;
    }

    public override void InteractWith()
    {
        if (isEnabled)
        {
            dm.GoToNight2();
        }
    }
}
