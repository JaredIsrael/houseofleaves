using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to be attached to all the saw traps in the scene.
//Used to animate the saws to look as though they are spinning.

public class Rotate : MonoBehaviour
{
    private float speed = 2f;

    private void Update()
    {
        transform.Rotate(0f, 0f, 360 * speed * Time.deltaTime);
    }
}
