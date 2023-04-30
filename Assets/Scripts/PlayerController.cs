using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*

Purpose: This class handles player movement for given input

Author: Cade Ciccone
 
 */

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Camera cam;
    public bool canMove = true;
    [SerializeField]
    private CameraRotator cr;

    public float speed = 7f;
    public bool crouching = false;
    public bool moving = false;
    public bool cameraHeightChanged = false;

    public bool usingFlashlight = false;
    public bool previousFlashlightInput = false;
    [SerializeField] private GameObject flashlight;

    public int throwableObjects = 0;
    public bool previousThrowableObjectInput = false;
    [SerializeField] GameObject objectToThrow;
    [SerializeField] GameObject throwPoint;

    private Vector2 keyboardInput;
    private float gravity;

    void Update()
    {
        gravity -= 9.81f;
        if (controller.isGrounded)
        {
            gravity = 0;
        }
        
        Vector3 movement3D = (transform.right * keyboardInput.x + transform.forward * keyboardInput.y) * speed;
        movement3D.y = gravity;
        // StopMovement and DisableMovement do the same thing, lets use the same one
        if (!canMove)
        {
            movement3D = Vector3.zero;
        }

        if(keyboardInput.x == 0 & keyboardInput.y == 0)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

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

    public void ReadFlashlightInput(bool flashlightInput)
    {
        if(!previousFlashlightInput && flashlightInput)
        {
            usingFlashlight = !usingFlashlight;
            flashlight.SetActive(usingFlashlight);
        }

        previousFlashlightInput = flashlightInput;
    }

    public void ReadThrowableObjectInput(bool throwableObjectInput)
    {
        if(throwableObjectInput && !previousThrowableObjectInput)
        {
            if(throwableObjects > 0)
            {
                Throw();
                throwableObjects--;
            }
            previousThrowableObjectInput = true;
        }
        else if(!throwableObjectInput && previousThrowableObjectInput)
        {
            previousThrowableObjectInput = false;
        }
    }

    public void Throw()
    {
        GameObject projectile = Instantiate(objectToThrow, throwPoint.transform.position, cam.transform.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(cam.transform.forward * 10 + transform.up, ForceMode.Impulse);

        //TO-DO: Add throw cooldown
    }

    /*

    These methods are used to move the player smoothly to a point, one has an
    additional transform the player will look at. You will almost certainly want
    to call DisableMovement() and LockCamera() before calling this.

     */
    public void MovePlayerToPointWithLook(Vector3 playerGoalPosition, Transform cameraLookGoal, float duration)
    {
        StartCoroutine(MovePlayerToPositionEnumerator(playerGoalPosition, cameraLookGoal, duration, true));
    }

    public void MovePlayerToPoint(Vector3 playerGoalPosition, float duration)
    {
        StartCoroutine(MovePlayerToPositionEnumerator(playerGoalPosition, null, duration, false));
    }

    // Use coroutines in order to animate smoothly without having an update method
    IEnumerator MovePlayerToPositionEnumerator(Vector3 playerGoalPosition, Transform cameraLookGoal, float duration, bool look)
    {
        float elapsedTime = 0f;
        float percentComplete = 0f;
        Vector3 startPos = transform.position;

        while (transform.position != playerGoalPosition)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime /duration;
            transform.position = Vector3.Lerp(startPos, playerGoalPosition, percentComplete);
            if(look)cam.transform.LookAt(cameraLookGoal);
            yield return null;
        }
    }

    /*
     
    These could be done with a toggle method or directly modifying instance vars, but
    this might reduce bugs and make any additional things we want to do on movmenet
    disable easier (UI icon?) Can easily be reworked later if need be

     */
    public void ToggleMovement()
    {
        canMove = !canMove;
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void UnLockCamera()
    {
        cr.EnableCameraMovment();
    }

    public void DisableCamera()
    {
        cam.gameObject.SetActive(false);
    }

    public void EnableCamera()
    {
        cam.gameObject.SetActive(true);
    }

    public void LockCamera()
    {
        cr.DisableCameraMovement();
    }
}
