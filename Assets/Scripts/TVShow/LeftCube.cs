using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCube : MonoBehaviour
{
    //TO-DO: inform player that they can not move past this point
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Turn Around!");
    }
}
