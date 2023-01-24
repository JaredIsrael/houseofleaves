using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Camera cam;

    public float speed = 0;

    private Vector2 keyboardInput;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement3D = (transform.right * keyboardInput.x + transform.forward * keyboardInput.y) * speed;

        controller.Move(movement3D * Time.deltaTime);
    }

    public void ReadInput(Vector2 input)
    {
        keyboardInput = input;
    }
}
