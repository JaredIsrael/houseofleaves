using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*

Purpose: This is the main CompletableTask script for the Cooking puzzle,
handles start, stop, and all mechanics. Listens for CookingPuzzleInteractable
to start.

Author: Jared Israel

 */

public class CookingPuzzle : CompletableTask
{
    [SerializeField]
    private CookingPuzzleInteractable interactable;
    [SerializeField]
    private PuzzleTimer pt;
    [SerializeField]
    private Transform lookPosition;
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private PlayerController pc;
    private float TRANSITION_DURATION = 1f;
    [SerializeField]
    private GameObject knife;
    private bool completed = false;
    private Vector3 initialPlayerPosition;

    void Start()
    {
        this.description = "Cook some food";
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(BeginPuzzle);
        pt.TimeRanOutEvent.AddListener(TimeRunOut);
        TaskCompletedEvent = new UnityEngine.Events.UnityEvent<CompletableTask>();
    }

    private void BeginPuzzle()
    {
        Debug.Log("runngi");
        // TaskCompletedEvent.Invoke(this);
        initialPlayerPosition = pc.gameObject.transform.position;
        pc.LockCamera();
        pc.DisableMovement();
        pc.MovePlayerToPointWithLook(playerPosition.position, lookPosition, TRANSITION_DURATION);
        StartCoroutine(TrackKnife());
    }

    IEnumerator TrackKnife()
    {
        Debug.Log("Tracking ");
        knife.transform.Rotate(new Vector3(-90, 0, 0));
        while (!completed)
        {
            if (Input.GetMouseButton(0))
            {
                completed = true;
                CompletePuzzle();
            }
            Vector3 newKnifePos = GetNewKnifePos();
            knife.transform.position = newKnifePos;

            yield return null;
        }
        knife.transform.Rotate(new Vector3(90, 0, 0));

    }

    private Vector3 GetNewKnifePos()
    {
        RaycastHit hit;
        Ray ray = pc.cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, 5, QueryTriggerInteraction.Ignore))
        {
            Transform objectHit = hit.transform;
            if (objectHit.gameObject.tag == "Table")
            {
                return hit.point;
            }
        }
        return knife.transform.position;
    }

    private void CompletePuzzle()
    {
        TaskCompletedEvent.Invoke(this);
        pt.DisableTimer();
        pc.MovePlayerToPoint(initialPlayerPosition, TRANSITION_DURATION);
        pc.EnableMovement();
        pc.UnLockCamera();
    }

    private void TimeRunOut()
    {
        completed = true;
    }
}