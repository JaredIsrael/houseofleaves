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
    [SerializeField]
    private CameraRotator cr;

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

    These methods are used to move the player smoothly to a point, one has an
    additional transform the player will look at. You will almost certainly want
    to call DisableMovement() and LockCamera() before calling this.

     */
    public void MovePlayerToPointWithLook(Transform playerGoalPosition, Transform cameraLookGoal, float duration)
    {
        StartCoroutine(MovePlayerToPositionEnumerator(playerGoalPosition.position, cameraLookGoal, duration, true));
    }

    public void MovePlayerToPoint(Transform playerGoalPosition, float duration)
    {
        StartCoroutine(MovePlayerToPositionEnumerator(playerGoalPosition.position, null, duration, false));

    }
    // Override for just a vector
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
        Vector3 goalPos = playerGoalPosition;

        while (transform.position != goalPos)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime /duration;
            transform.position = Vector3.Lerp(startPos, goalPos, percentComplete);
            if(look)cam.transform.LookAt(cameraLookGoal);
            yield return null;
        }
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

    public void LockCamera()
    {
        cr.DisableCameraMovement();
    }

    public void UnLockCamera()
    {
        cr.EnableCameraMovment();
    }

}
