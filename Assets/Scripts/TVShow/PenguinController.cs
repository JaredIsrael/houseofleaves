using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenguinController : MonoBehaviour
{
    private PenguinActions penguinActions;
    private InputAction walk;
    private InputAction jump;
    private InputAction slide;

    public Animator animator;
    public SpriteRenderer spRenderer;
    private float speed = 0.05f;

    private bool walking;
    private bool jumping;
    private bool sliding;

    void Awake()
    {
        penguinActions = new PenguinActions();
    }

    private void OnEnable()
    {
        walk = penguinActions.Player.Walk;
        walk.Enable();

        penguinActions.Player.Walk.performed += PenguinWalk;
        penguinActions.Player.Walk.Enable();

        penguinActions.Player.Jump.performed += PenguinJump;
        penguinActions.Player.Jump.Enable();

        penguinActions.Player.Slide.performed += PenguinSlide;
        penguinActions.Player.Slide.Enable();
    }

    private void Walk()
    {
        walking = (walk.ReadValue<Vector2>().x > 0.1f || walk.ReadValue<Vector2>().x < -0.1f);
        animator.SetBool("Walk", walking);
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");
        if (!jumping)
        {
            animator.SetTrigger("Jump");
            StartCoroutine(StartAction(jumping));
        }
    }

    private void Slide()
    {
        if (!sliding)
        {
            animator.SetTrigger("Slide");
            StartCoroutine(StartAction(sliding));
        }
    }

    private IEnumerator StartAction(bool action)
    {
        yield return new WaitForSeconds(0.1f);
        action = true;
    }

    private void PenguinWalk(InputAction.CallbackContext obj)
    {
        Debug.Log("Walk!!");
        Walk();
    }

    private void PenguinJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump!!");
        Jump();
    }

    private void PenguinSlide(InputAction.CallbackContext obj)
    {
        Debug.Log("Slide!!");
        Slide();
    }

    private void OnDisable()
    {
        walk.Disable();
        penguinActions.Player.Jump.Disable();
        penguinActions.Player.Slide.Disable();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(walk.ReadValue<Vector2>().x * speed, 0f, walk.ReadValue<Vector2>().y * speed);
        if (walk.ReadValue<Vector2>().x < 0)
        {
            spRenderer.flipX = true;
        } else if (walk.ReadValue<Vector2>().x == 0) {
            //return to idle state
            animator.SetBool("Walk", false);
        }
        else
        {
            spRenderer.flipX = false;
        }
    }
}
