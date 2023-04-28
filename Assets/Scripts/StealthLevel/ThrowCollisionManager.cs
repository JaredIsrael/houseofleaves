using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCollisionManager : MonoBehaviour
{
    public void broadcast(Vector3 position)
    {
        BroadcastMessage("thrownObjectDetection", position);
    } 
}
