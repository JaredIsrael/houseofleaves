using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCube : MonoBehaviour
{

    [SerializeField] private GameObject bubble;

    //TO-DO: inform player that they can not move past this point
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Turn Around!");
        bubble.SetActive(true);

        //destroys bubble before any other text appears
        Destroy(bubble, 4.0f);
    }
}
