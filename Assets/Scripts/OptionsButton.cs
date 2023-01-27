using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField]
    private MenuManager mm;

    public void OpenOptionsMenu()
    {
        // Just calls options manager, but if we want sound functionality, here is a good place
        mm.SwitchToOptionsCanvas();
    }
}
