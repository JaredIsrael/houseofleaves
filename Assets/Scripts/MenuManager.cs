using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Canvas optionsCanvas;

    public void SwitchToOptionsCanvas()
    {
        menuCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(true);
    }

    public void SwitchToMenuCanvas()
    {
        menuCanvas.gameObject.SetActive(true);
        optionsCanvas.gameObject.SetActive(false);
    }
}
