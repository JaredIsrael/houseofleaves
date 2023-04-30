using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to be attached to any keys in the Platformer scene.
//Adds a bobbing animation to the keys. 

public class KeyFloat : MonoBehaviour
{
    private float initial;
    private float strength = 0.25f;

    void Start()
    {
        initial = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, initial + ((float)Mathf.Sin(Time.time) * strength), transform.position.z);
    }
}
