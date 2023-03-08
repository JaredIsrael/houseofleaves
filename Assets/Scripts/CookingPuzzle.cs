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
    private float SLICE_DURATION = 1f;
    [SerializeField]
    private GameObject knife;
    private bool completed = false;
    private Vector3 initialPlayerPosition;

    private Coroutine trackingCoroutine;

    private void Awake()
    {
        TaskCompletedEvent = new UnityEngine.Events.UnityEvent<CompletableTask>();
    }

    void Start()
    {
        this.description = "Cook some food";
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(BeginPuzzle);
        pt.TimeRanOutEvent.AddListener(TimeRunOut);
    }

    private void BeginPuzzle()
    {
        // TaskCompletedEvent.Invoke(this);
        initialPlayerPosition = pc.gameObject.transform.position;
        pc.LockCamera();
        pc.DisableMovement();
        pc.MovePlayerToPointWithLook(playerPosition.position, lookPosition, TRANSITION_DURATION);
        knife.transform.Rotate(new Vector3(-90, 0, 0));
        trackingCoroutine = StartCoroutine(TrackKnife());
    }

    IEnumerator TrackKnife()
    {
        while (!completed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SliceKnife();
            }
            if (Input.GetKeyDown(KeyCode.Space))
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

    private void SliceKnife()
    {
        StartCoroutine(MoveKnifeDown(SLICE_DURATION));
    }

    // Use coroutines in order to animate smoothly without having an update method
    IEnumerator MoveKnifeDown(float duration)
    {
        StopCoroutine(trackingCoroutine);
        float elapsedTime = 0f;
        float percentComplete = 0f;
        Vector3 startPos = knife.transform.position;
        Vector3 goalPosition = knife.transform.position - new Vector3(0, 0.2f, 0);

        while (knife.transform.position != goalPosition && elapsedTime<2f)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / duration;
            knife.transform.position = Vector3.Slerp(startPos, goalPosition, percentComplete);
            yield return null;
        }
        knife.transform.position = startPos;

        trackingCoroutine = StartCoroutine(TrackKnife());
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
                return hit.point+new Vector3(0,0.1f,0);
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