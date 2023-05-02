using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoStarter : MonoBehaviour
{
    [SerializeField] Canvas pianoCanvas;
    [SerializeField] PianoController pianoController;
    [SerializeField] InputManager inputManager;
    [SerializeField] AudioSource hint;

    private void Start()
    {
        hint.loop = true;
        hint.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hint.Stop();
            Cursor.visible = true;
            pianoCanvas.gameObject.SetActive(true);
            inputManager.TogglePlayerMovement();
            pianoController.SetUpContexts();
            pianoController.inputActions.Enable();
            inputManager.inputActions.Disable();
            inputManager.DeleteContexts();

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
        Cursor.visible = false;
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
