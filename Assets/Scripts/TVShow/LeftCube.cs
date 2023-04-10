using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCube : MonoBehaviour
{

    [SerializeField] private GameObject bubble;

    //informs player that they can not move past this point
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bubble.SetActive(true);

        //destroys bubble after 4 seconds, before any other text appears
        Destroy(bubble, 4.0f);
    }
}