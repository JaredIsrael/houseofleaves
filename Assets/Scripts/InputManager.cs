using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] CameraRotator rotator;
    [SerializeField] GameStateManager gameStateManager;
    [SerializeField] PianoController pianoController;

    public static PlayerController playerController;
    public static InputActions inputActions;
    public static event Action<InputActionMap> actionMapChange;

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
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        paused = false;

        //Movement contexts
        inputActions.Player.Move.performed += ctx => keyboardInput = ctx.ReadValue<Vector2>();
        inputActions.Player.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        inputActions.Player.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        //Pick up contexts
        inputActions.Player.PickUp.performed += ctx => pickUp = ctx.ReadValueAsButton();
        inputActions.Player.PickUp.performed += ctx => PickUpController.Instance.TryPickupItems();
        //Objective contexts
        inputActions.Player.Objectives.performed += ctx => ToDoListManager.Instance.ToggleList();
        //UI contexts
        UIActions.Inputs.Pause.performed += ctx => paused = ctx.ReadValueAsButton();
        UIActions.Inputs.Reset.performed += ctx => reset = ctx.ReadValueAsButton();
        UIActions.Inputs.Exit.performed += ctx => exit = ctx.ReadValueAsButton();

        ToggleActionMap(inputActions.Player);
    }

    public static void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
            return;
        inputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
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
    
    public InputActions GetInputActions()
    {
        return inputActions;
    }

    public static void StopPlayerMovement()
    {
        playerController.StopMovement();
    }

    public static void StartPlayerMovement()
    {
        playerController.StartMovement();
    }
}
