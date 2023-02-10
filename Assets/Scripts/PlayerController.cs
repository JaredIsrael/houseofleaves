using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*

Purpose: This class handles player movement for given input

Author: 
 
 */

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Camera cam;

    public float speed = 7f;
    public bool crouching = false;
    public bool cameraHeightChanged = false;

    private Vector2 keyboardInput;

    void Update()
    {
        Vector3 movement3D = (transform.right * keyboardInput.x + transform.forward * keyboardInput.y) * speed;

        controller.Move(movement3D * Time.deltaTime);
    }

    public void ReadInput(Vector2 input)
    {
        keyboardInput = input;
    }

    public void ReadCrouchInput(bool crouchInput)
    {
        crouching = crouchInput;

        if (crouching)
        {
            speed = 3.5f;
            controller.height = 1f;

            if(!cameraHeightChanged)
            {
                cam.transform.position = cam.transform.position + new Vector3(0, -1, 0);
                cameraHeightChanged = true;
            }
        }
        else
        {
            if(!Physics.Raycast(cam.transform.position, Vector3.up, 1f))
            {
                speed = 7f;
                controller.height = 2f;

                if (cameraHeightChanged)
                {
                    cam.transform.position = cam.transform.position + new Vector3(0, 1, 0);
                    cameraHeightChanged = false;
                }
            }
        }
    }
}
