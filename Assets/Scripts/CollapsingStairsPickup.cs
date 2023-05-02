using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingStairsPickup: MonoBehaviour
{
    [SerializeField]
    private GameObject stairs;
    [SerializeField]
    private GameObject frame;
    [SerializeField]
    private GameObject flashlight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(stairs);
            Destroy(frame);
            Destroy(flashlight);
        }
    }
}
