using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*

Purpose: This class handles player movement for controller input, disabling movement,
and camera management

Author: 
 
 */

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Camera cam;
    private bool canMove = true;

    public float speed = 0;

    private Vector2 keyboardInput;

    void Update()
    {
        Vector3 movement3D = (transform.right * keyboardInput.x + transform.forward * keyboardInput.y) * speed;
        if (!canMove)
        {
            movement3D = Vector3.zero;
        }
        controller.Move(movement3D * Time.deltaTime);

    }

    public void ReadInput(Vector2 input)
    {
        keyboardInput = input;
    }

    /*
     
    These could be done with a toggle method or directly modifying instance vars, but
    this might reduce bugs and make any additional things we want to do on movmenet
    disable easier (UI icon?) Can easily be reworked later if need be

     */
    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void DisableCamera()
    {
        cam.gameObject.SetActive(false);
    }

    public void EnableCamera()
    {
        cam.gameObject.SetActive(true);
    }

}
