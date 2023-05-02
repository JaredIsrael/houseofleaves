using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitsGround : MonoBehaviour
{
    private ThrowCollisionManager collisionManager;
    private GameObject glassShatter;

    void Start()
    {
        glassShatter = GameObject.Find("GlassShatter");
        glassShatter.GetComponent<AudioSource>().Play();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        collisionManager = GameObject.Find("ThrownObjectCollisionManager").GetComponent<ThrowCollisionManager>();
        collisionManager.broadcast(collisionInfo.contacts[0].point);
        Destroy(this.gameObject);
    }
}
