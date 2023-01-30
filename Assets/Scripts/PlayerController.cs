using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Camera cam;
    [SerializeField] PickUpController pickUpController;
    [SerializeField] RoomManipulator roomManipulator;

    public float speed = 0;

    private Vector2 keyboardInput;
    private bool pickedUp;

    void Awake()
    {
        
    }

    void Update()
    {
        Vector3 movement3D = (transform.right * keyboardInput.x + transform.forward * keyboardInput.y) * speed;

        controller.Move(movement3D * Time.deltaTime);

        if (pickedUp && pickUpController.CanBePickedUp())
        {
            roomManipulator.Move();
            pickUpController.StopChecking();
        }
    }

    public void ReadInput(Vector2 input, bool pickUp)
    {
        keyboardInput = input;
        pickedUp = pickUp;
    }
}
