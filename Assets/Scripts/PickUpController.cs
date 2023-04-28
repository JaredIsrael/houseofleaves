using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/*

Purpose: This class is a singleton that persists between scenes to manage any
items that can be picked up. It provides a simple method that we can bind to
our interact button while keeping track of objects that can be picked up. When
the button is pressed, it picks everything up that it can (this could be changed
to pickup closest or most recent.) Items should add themselves to it when they
are available to be picked up (see PickUpSphere.cs)

Author: Jared Israel
 
 */

public class PickUpController : MonoBehaviour
{
    public static PickUpController Instance;

    private List<Interactable> canBePickedUpList;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Pickup screen will be reused in different scenes
            canBePickedUpList = new List<Interactable>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canBePickedUpList = new List<Interactable>();
    }

    public void AddToPickUpList(Interactable item)
    {
        canBePickedUpList.Add(item);
    }

    public void RemoveFromPickupList(Interactable item)
    {
        canBePickedUpList.Remove(item);
    }

    public void TryPickupItems()
    {
        foreach(Interactable i in canBePickedUpList)
        {
            i.InteractWith();
        }
    }
}
