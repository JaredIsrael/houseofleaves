using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    PlayerController playerController;

    private double enemyHearingThreshold = 1.5;
    
    private double playerSound;
    private double distanceFromPlayer;

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

        if(playerIsCrouching)
        {
            playerSound = 10;
        }
        else
        {
            playerSound = 5;
        }

        /*
        if(playerIsMoving)
        {
            if (playerSound / distanceFromPlayer < enemyHearingThreshold)
            {
                Debug.Log("I HEAR YOU");
            }
            else
            {
                Debug.Log("nope");
            }
        } 
        else
        {
            Debug.Log("nope");
        }*/
    }

}
