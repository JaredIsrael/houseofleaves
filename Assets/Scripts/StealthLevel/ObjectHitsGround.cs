using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitsGround : MonoBehaviour
{
    private ThrowCollisionManager collisionManager;
    private AudioSource source;

    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collisionInfo) 
    {
        collisionManager = GameObject.Find("ThrownObjectCollisionManager").GetComponent<ThrowCollisionManager>();
        collisionManager.broadcast(collisionInfo.contacts[0].point);

        if(source != null)
        {
            Debug.Log("Yay");
        }
        else
        {
            Debug.Log("Fuck");
        }

        Destroy(this.gameObject);
    }
}
