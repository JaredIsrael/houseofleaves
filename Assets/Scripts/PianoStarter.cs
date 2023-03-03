using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoStarter : MonoBehaviour
{
    [SerializeField] Canvas pianoCanvas;
    [SerializeField] PianoController pianoController;
    [SerializeField] InputManager inputManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pianoCanvas.gameObject.SetActive(true);
            inputManager.StopPlayerMovement();
            inputManager.inputActions.Disable();
            pianoController.inputActions.Enable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pianoCanvas.gameObject.SetActive(false);
            pianoController.inputActions.Disable();
            inputManager.inputActions.Enable();
            inputManager.StartPlayerMovement();
        }
    }

    public void Quit()
    {
        pianoCanvas.gameObject.SetActive(false);
        pianoController.inputActions.Disable();
        inputManager.inputActions.Enable();
        inputManager.StartPlayerMovement();
    }
}
