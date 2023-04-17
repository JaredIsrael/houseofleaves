using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spRenderer;
    [SerializeField] private Animator animator;

    private float horizontal;

    private enum AnimationState { idle, walk, jump, slide }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * 7f, rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 14f);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        AnimationState state;

        //walk state
        if (horizontal > 0f)
        {
            state = AnimationState.walk;
            spRenderer.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = AnimationState.walk;
            spRenderer.flipX = true;
        }
        else
        {
            state = AnimationState.idle;
        }

        //jump state
        if (rigidBody.velocity.y > 0.1f)
        {
            state = AnimationState.jump;
        }

        animator.SetInteger("State", ((int)state));
    }
}
