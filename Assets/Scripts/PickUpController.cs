using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] Canvas PickUpScreen;
    
    private bool canBePickedUp;
    private bool stopChecking;

    void Start()
    {
        PickUpScreen.gameObject.SetActive(false);
    }

    public bool CanBePickedUp()
    {
        return canBePickedUp;
    }

    public void StopChecking()
    {
        gameObject.SetActive(false);
        PickUpScreen.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpScreen.gameObject.SetActive(true);
            canBePickedUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUpScreen.gameObject.SetActive(false);
            canBePickedUp = false;
        }
    }
}
