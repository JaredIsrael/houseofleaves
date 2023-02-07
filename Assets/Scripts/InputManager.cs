using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] CameraRotator rotator;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameStateManager gameStateManager;

    private InputActions inputActions;
    private UIInputs UIActions;
    private Vector2 keyboardInput;
    private Vector2 mouseInput;
    private bool pickUp;
    private bool paused;
    private bool reset;
    private bool exit;

    private void Awake()
    {
        inputActions = new InputActions();
        UIActions = new UIInputs();
        paused = false;

        inputActions.Player.Move.performed += ctx => keyboardInput = ctx.ReadValue<Vector2>();
        inputActions.Player.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        inputActions.Player.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        inputActions.Player.PickUp.performed += ctx => pickUp = ctx.ReadValueAsButton();
        inputActions.Player.PickUp.performed += ctx => PickUpController.Instance.TryPickupItems();
        inputActions.Player.Objectives.performed += ctx => ToDoListManager.Instance.ToggleList();
        UIActions.Inputs.Pause.performed += ctx => paused = ctx.ReadValueAsButton();
        UIActions.Inputs.Reset.performed += ctx => reset = ctx.ReadValueAsButton();
        UIActions.Inputs.Exit.performed += ctx => exit = ctx.ReadValueAsButton();
    }

    private void Update()
    {
        playerController.ReadInput(keyboardInput);
        rotator.ReadInput(mouseInput);
        gameStateManager.ReadPauseInput(paused, exit);
        gameStateManager.ReadResetInput(reset);
    }

    private void OnEnable()
    {
        inputActions.Enable();
        UIActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
        UIActions.Disable();
    }
}
