using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: This script goes on the clothing items that are used for the laundry game,
it randomly chooses a color and handles animation for going to baskets.

Author: Jared Israel

 */

public class LaundryItem : MonoBehaviour
{
    public BasketColor color;
    [SerializeField]
    private MeshRenderer mr;
    [SerializeField]
    private List<Material>mats;
    private const float TRANSITION_DURATION = 1.5f;

    private void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 130f, 0);
        int rand = Random.Range(0, 5);
        switch (rand)
        {
            case 0:
                color = BasketColor.Black;
                mr.material = mats[rand];
                break;
            case 1:
                color = BasketColor.Blue;
                mr.material = mats[rand];
                break;
            case 2:
                color = BasketColor.White;
                mr.material = mats[rand];
                break;
            case 3:
                color = BasketColor.Red;
                mr.material = mats[rand];
                break;
            case 4:
                color = BasketColor.Green;
                mr.material = mats[rand];
                break;
        }
    }

    public void moveToPosition(Transform moveTo)
    {
        //this.transform.position = moveTo.position;
        StartCoroutine(MoveItemToPositionEnumerator(moveTo.position, TRANSITION_DURATION));
    }

    public void ShakeAnimate()
    {
        Debug.Log("Shake animation");
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
            transform.position = Vector3.Slerp(startPos,goalPosition, percentComplete);
            yield return null;
        }
        this.gameObject.SetActive(false);
    }

    IEnumerator ShakeAnimateEnumerator()
    {
        yield return null;
    }
}
