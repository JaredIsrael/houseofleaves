using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used with any objects in the scene that move back and forth
//between two points (waypoints).

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int index = 0;

    private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[index].transform.position, transform.position) < 0.1f)
        {
            index++;
            if (index >= waypoints.Length)
            {
                index = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[index].transform.position, Time.deltaTime * speed);
    }
}
