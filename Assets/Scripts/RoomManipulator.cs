using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManipulator : MonoBehaviour
{

    [SerializeField] GameObject WallToMove;
    [SerializeField] GameObject[] Lights;
    public float movementSpeed;

    private Vector3 wallMovement;
    private Vector3 endPosition;
    private bool canMove;
    private AudioSource audioSource;

    void Start()
    {
        wallMovement = new Vector3(0, 0, movementSpeed);
        endPosition = WallToMove.transform.position;
        audioSource = WallToMove.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canMove)
        {
            if (WallToMove.transform.position.z < 15)
            {
                WallToMove.transform.position += wallMovement * Time.deltaTime;
                if (WallToMove.transform.position.z > Lights[0].transform.position.z)
                {
                    Lights[0].SetActive(true);
                    Lights[1].SetActive(true);
                }
            }
            else
            {
                audioSource.Stop();
                WallToMove.transform.position = endPosition + new Vector3(0, 0, 10);
            }
        }
    }

    public void Move()
    {
        canMove = true;
        audioSource.Play();
    }
}
