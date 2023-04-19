using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] CameraRotator rotator;
    [SerializeField] GameStateManager gameStateManager;

    public PlayerController playerController;
    public InputActions inputActions;

    //changed this to public static from private
    public static UIInputs UIActions;
    private Vector2 keyboardInput;
    private Vector2 mouseInput;
    private bool crouch;
    private bool pickUp;
    private bool throwObject;
    private bool paused;
    private bool reset;
    private bool exit;

    private void Awake()
    {
        inputActions = new InputActions();
        UIActions = new UIInputs();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        paused = false;

        SetUpContexts();
    }

    private void Update()
    {
        playerController.ReadInput(keyboardInput);
        playerController.ReadCrouchInput(crouch);
        playerController.ReadThrowableObjectInput(throwObject);
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

    public void SetUpContexts()
    {
        //Movement contexts
        inputActions.Player.Move.performed += ctx => keyboardInput = ctx.ReadValue<Vector2>();
        inputActions.Player.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        inputActions.Player.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        inputActions.Player.Crouch.performed += ctx => crouch = ctx.ReadValueAsButton();
        inputActions.Player.ThrowObject.performed += ctx => throwObject = ctx.ReadValueAsButton();
        inputActions.Player.PickUp.performed += ctx => pickUp = ctx.ReadValueAsButton();
        inputActions.Player.PickUp.started += ctx => PickUpController.Instance.TryPickupItems();
        inputActions.Player.Objectives.started += ctx => ToDoListManager.Instance.ToggleList();
        UIActions.Inputs.Pause.performed += ctx => paused = ctx.ReadValueAsButton();
        UIActions.Inputs.Reset.performed += ctx => reset = ctx.ReadValueAsButton();
        UIActions.Inputs.Exit.performed += ctx => exit = ctx.ReadValueAsButton();
    }

    public void DeleteContexts()
    {
        //Movement contexts
        inputActions.Player.Move.performed -= ctx => keyboardInput = ctx.ReadValue<Vector2>();
        inputActions.Player.MouseX.performed -= ctx => mouseInput.x = ctx.ReadValue<float>();
        inputActions.Player.MouseY.performed -= ctx => mouseInput.y = ctx.ReadValue<float>();
        inputActions.Player.Crouch.performed -= ctx => crouch = ctx.ReadValueAsButton();
        inputActions.Player.ThrowObject.performed += ctx => throwObject = ctx.ReadValueAsButton();
        inputActions.Player.PickUp.performed -= ctx => pickUp = ctx.ReadValueAsButton();
        inputActions.Player.PickUp.started -= ctx => PickUpController.Instance.TryPickupItems();
        inputActions.Player.Objectives.started -= ctx => ToDoListManager.Instance.ToggleList();
        UIActions.Inputs.Pause.performed -= ctx => paused = ctx.ReadValueAsButton();
        UIActions.Inputs.Reset.performed -= ctx => reset = ctx.ReadValueAsButton();
        UIActions.Inputs.Exit.performed -= ctx => exit = ctx.ReadValueAsButton();
    }
    
    public InputActions GetInputActions()
    {
        return inputActions;
    }

    public void TogglePlayerMovement()
    {
        playerController.ToggleMovement();
    }
}
