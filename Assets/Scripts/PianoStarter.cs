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
            inputManager.TogglePlayerMovement();
            pianoController.SetUpContexts();
            pianoController.inputActions.Enable();
            inputManager.inputActions.Disable();
            inputManager.DeleteContexts();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pianoCanvas.gameObject.SetActive(false);
            pianoController.inputActions.Disable();
            inputManager.inputActions.Enable();
            inputManager.TogglePlayerMovement();
        }
    }

    public void Quit()
    {
        foreach (BoxCollider collider in gameObject.GetComponents<BoxCollider>())
        {
            if (collider.isTrigger)
            {
                collider.enabled = false;
                StartCoroutine(WaitToEnable(5, collider));
            }
        }
        pianoCanvas.gameObject.SetActive(false);
        pianoController.DeleteContexts();
        pianoController.inputActions.Disable();
        inputManager.inputActions.Enable();
        inputManager.SetUpContexts();
        inputManager.TogglePlayerMovement();
    }

    private IEnumerator WaitToEnable(float waitTime, BoxCollider collider)
    {
        yield return new WaitForSeconds(waitTime);
        collider.enabled = true;
    }
}
