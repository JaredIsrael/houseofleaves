using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] CameraRotator rotator;
    [SerializeField] PlayerController playerController;

    private InputActions inputActions;
    private Vector2 keyboardInput;
    private Vector2 mouseInput;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.Move.performed += ctx => keyboardInput = ctx.ReadValue<Vector2>();

        inputActions.Player.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        inputActions.Player.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        playerController.ReadInput(keyboardInput);
        rotator.ReadInput(mouseInput);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
