using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingIngredient : MonoBehaviour
{
    public GameObject target;
    private const float SLIDE_DURATION = 1.0f;
    private Coroutine animationCoroutine;

    private void Awake()
    {
        ShowTarget(false);
    }

    public void ShowTarget(bool on)
    {
        target.SetActive(on);
    }

    public void StopAnimating()
    {
        StopCoroutine(animationCoroutine);
    }

    // DUPLICATED CODE: See 
    public void MoveToPosition(Transform moveTo)
    {
        //this.transform.position = moveTo.position;
        animationCoroutine = StartCoroutine(MoveItemToPositionEnumerator(moveTo.position, SLIDE_DURATION));
    }

    // Use coroutines in order to animate smoothly without having an update method
    IEnumerator MoveItemToPositionEnumerator(Vector3 goalPosition, float duration)
    {
        float elapsedTime = 0f;
        float percentComplete = 0f;
        Vector3 startPos = transform.position;

        while (transform.position != goalPosition)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / duration;
            transform.position = Vector3.Slerp(startPos, goalPosition, percentComplete);
            yield return null;
        }
    }

}


