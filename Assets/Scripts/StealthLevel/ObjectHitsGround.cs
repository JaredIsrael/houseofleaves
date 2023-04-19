using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitsGround : MonoBehaviour
{
    private ThrowCollisionManager collisionManager;

    void OnCollisionEnter(Collision collisionInfo) 
    {
        collisionManager = GameObject.Find("ThrownObjectCollisionManager").GetComponent<ThrowCollisionManager>();
        collisionManager.broadcast(collisionInfo.contacts[0].point);

        Destroy(this.gameObject);
    }
}
