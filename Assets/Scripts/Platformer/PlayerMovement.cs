using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //!!TO-DO: configure to new input system!!

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask jumpGround;

    private float horizontal;
    private bool sliding;

    private enum AnimationState { idle, walk, jump, slide }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * 7f, rigidBody.velocity.y);

        //jump if the "return" key is clicked AND the player is on the ground
        if (Input.GetKeyDown(KeyCode.Return) && OnGround())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 14f);
        }

        //slide if the "shift" key is clicked AND the player is on the ground
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && OnGround())
        {
            sliding = true;
        } else
        {
            sliding = false;
        }

        UpdateAnimationState();
    }

    //method that switches between animator states
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

        //slide state
        if (sliding)
        {
            state = AnimationState.slide;
        }

        //jump state
        if (rigidBody.velocity.y > 0.1f)
        {
            state = AnimationState.jump;
        }

        animator.SetInteger("State", ((int)state));
    }

    //boolean method to determine if player is on the ground
    private bool OnGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }
}
