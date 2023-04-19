using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private GameObject player;
    PlayerController playerController;

    private double enemyHearingThreshold = 1;

    private double walkingVolume = 10;
    private double crouchingVolume = 5;
    private double playerSound;
    private double distanceFromPlayer;

    private double objectSound = 5;
    private double distanceFromObjectCollision;

    private bool playerIsCrouching;
    private bool playerIsMoving;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        playerDetection();
    }

    void playerDetection()
    { 
        distanceFromPlayer = Vector3.Distance(player.transform.position, this.transform.position);
        playerIsCrouching = playerController.crouching;
        playerIsMoving = playerController.moving;

        if(!playerIsCrouching)
        {
            playerSound = walkingVolume;
        }
        else
        {
            playerSound = crouchingVolume;
        }

        if(playerIsMoving)
        {
            if (playerSound / distanceFromPlayer > enemyHearingThreshold)
            {
                GetComponent<EnemyNavigation>().investigate(player.transform.position);
            }
        } 
    }

    public void thrownObjectDetection(Vector3 position)
    {
        distanceFromObjectCollision = Vector3.Distance(position, this.transform.position);

        if(objectSound / distanceFromObjectCollision > enemyHearingThreshold)
        {
            GetComponent<EnemyNavigation>().investigate(position);
        }
    }

}
