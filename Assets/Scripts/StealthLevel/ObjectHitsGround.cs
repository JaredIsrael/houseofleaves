using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitsGround : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo) 
    {
        Debug.Log("Collision Detected");

        //TODO: Trigger Enemy

        Destroy(this.gameObject);
    }
}
