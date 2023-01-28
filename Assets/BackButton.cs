using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    [SerializeField]
    MenuManager mm;

    public void BackToMenu()
    {
        mm.SwitchToMenuCanvas();
    }
}
