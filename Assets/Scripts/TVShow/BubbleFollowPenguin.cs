using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFollowPenguin : MonoBehaviour
{
    public Transform penguin;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(1f, .5f, 0f);
    }

    //camera follows penguin as it walks around scene
    void Update()
    {
        transform.position = penguin.transform.position + offset;
    }
}
