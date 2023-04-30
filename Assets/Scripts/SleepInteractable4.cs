using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepInteractable4 : PickUpSphere
{

    [SerializeField]
    private Day4Manager dm;
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
            dm.GoToNight1();
        }
    }
}
