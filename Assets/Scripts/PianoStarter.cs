using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoStarter : MonoBehaviour
{
    [SerializeField] Canvas pianoCanvas;
    [SerializeField] PianoController pianoController;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pianoCanvas.gameObject.SetActive(true);
            //pianoController.EnableActions();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            pianoCanvas.gameObject.SetActive(false);
    }
}
