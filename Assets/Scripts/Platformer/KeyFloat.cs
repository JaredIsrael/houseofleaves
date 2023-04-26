using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFloat : MonoBehaviour
{
    private float initial;
    private float strength = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        initial = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, initial + ((float)Mathf.Sin(Time.time) * strength), transform.position.z);
    }
}
