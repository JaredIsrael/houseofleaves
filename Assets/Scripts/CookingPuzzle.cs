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
    private const float TRANSITION_DURATION = 1f;
    private const float SLICE_DURATION = 1.0f;
    private const float PUZZLE_TIME_LIMIT = 20f;
    private const float CUT_DELAY = 1.0f;
    [SerializeField]
    private GameObject knife;
    private bool completed = false;
    private Vector3 initialPlayerPosition;

    [SerializeField]
    private Transform defaultKnifePos;
    [SerializeField]
    private Transform activeKnifePos;
    [SerializeField]
    private Transform leftIngredientPos;
    [SerializeField]
    private Transform rightIngredientPos;

    private Coroutine trackingCoroutine;
    [SerializeField]
    private MonologLines tastyLines;
    [SerializeField]
    private MonologLines failedLines;
    [SerializeField]
    private AudioSource sliceSource;
    private bool failed;

    [SerializeField]
    private List<CookingIngredient> ingredients;
    private int currentIngredient;

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
        pc.ToggleMovement();
        pc.MovePlayerToPointWithLook(playerPosition.position, lookPosition, TRANSITION_DURATION);
        knife.transform.Rotate(new Vector3(-90, 0, 0));
        currentIngredient = 0;
        trackingCoroutine = StartCoroutine(TrackKnife());
        knife.transform.position = activeKnifePos.position;
        StartCoroutine(AnimationDelay());
        failed = false;
    }

    private IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(CUT_DELAY);
        if (currentIngredient > 0)
        {
            if (ingredients[currentIngredient-1] != null && ingredients[currentIngredient - 1].GetComponentInChildren<CookingIngredient>().target != null)
            {
                Debug.Log("FIALEd");
                ingredients[currentIngredient-1].gameObject.SetActive(false);
                failed = true;
            }
        }
        if(currentIngredient >= ingredients.Count)
        {
            CompletePuzzle();
        }
        else
        {
            AnimateCurrentIngredient();
        }
    }

    private void AnimateCurrentIngredient()
    {
        CookingIngredient ingredient = ingredients[currentIngredient];
        ingredient.ShowTarget(true);
        ingredient.transform.position = leftIngredientPos.position;
        ingredient.transform.rotation = Quaternion.Euler(0, 180, 0);
        ingredient.MoveToPosition(rightIngredientPos);
    }

    IEnumerator TrackKnife()
    {
        while (!completed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ingredients[currentIngredient].StopAnimating();
                SliceKnife();
                currentIngredient++;
            }

            yield return null;
        }
        knife.transform.Rotate(new Vector3(90, 0, 0));
        knife.transform.position = defaultKnifePos.position;

    }

    private void SliceKnife()
    {
        float dist = Vector3.Distance(knife.transform.position, ingredients[currentIngredient].target.transform.position);
        Debug.Log("Distance = " + dist);

        sliceSource.Play();
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
        StartCoroutine(AnimationDelay());
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
        completed = true;
        TaskCompletedEvent.Invoke(this);
        pc.MovePlayerToPoint(initialPlayerPosition, TRANSITION_DURATION);
        pc.ToggleMovement();
        pc.UnLockCamera();
        if (failed)
        {
            DialogManager.Instance.DisplayMonologLines(failedLines);
        }
        else
        {
            DialogManager.Instance.DisplayMonologLines(tastyLines);

        }
    }

    private void TimeRunOut()
    {
        completed = true;
    }
}