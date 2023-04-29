using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this script is make the player "stick" to any moving
//platforms when they are standing on top. This is achieved by making the
//player a child of the platform when they are on top, and then remove them as
//a child when they jump off.

public class StickToPlatform : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
