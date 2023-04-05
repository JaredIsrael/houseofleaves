using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform penguin;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0f, 0.5f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = penguin.transform.position + offset;
    }
}
