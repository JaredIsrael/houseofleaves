using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform penguin;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = penguin.transform.position + offset;
    }
}
