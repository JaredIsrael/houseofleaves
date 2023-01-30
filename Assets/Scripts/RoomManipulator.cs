using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManipulator : MonoBehaviour
{

    [SerializeField] GameObject WallToMove;
    public float movementSpeed;

    private Vector3 wallMovement;
    private Vector3 endPosition;
    private bool canMove;

    void Start()
    {
        wallMovement = new Vector3(0, 0, movementSpeed);
        endPosition = WallToMove.transform.position;
    }

    void Update()
    {
        if (canMove)
        {
            if (WallToMove.transform.position.z < 15)
            {
                WallToMove.transform.position += wallMovement * Time.deltaTime;
            }
            else
            {
                WallToMove.transform.position = endPosition + new Vector3(0, 0, 10);
            }
        }
    }

    public void Move()
    {
        canMove = true;
    }
}
