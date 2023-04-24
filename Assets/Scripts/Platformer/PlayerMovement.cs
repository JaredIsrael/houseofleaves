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

    [SerializeField] private AudioSource jumpSound;

    private float horizontal;
    private bool sliding;
    private int layer;

    private enum AnimationState { idle, walk, jump, slide }

    private void Start()
    {
        //for raycast on objects in Ground layer
        layer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * 7f, rigidBody.velocity.y);

        //jump if the "return" key is clicked AND the player is on the ground
        if (Input.GetKeyDown(KeyCode.Return) && OnGround())
        {
            if (rigidBody.bodyType != RigidbodyType2D.Static)
            {
                jumpSound.Play();
            }
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 14f);
        }

        //slide if the "shift" key is clicked AND the player is on the ground
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && OnGround())
        {
            sliding = true;
        }
        else if (sliding && Physics2D.Raycast(transform.position, Vector2.up, 2, layer))
        { //raycast - if there is an object above the player, they can't exit slide
            Debug.Log("hitting");
            sliding = true;
        }
        else
        {
            sliding = false;
        }

        UpdateAnimationState();
    }

    //method that switches between animator states
    private void UpdateAnimationState()
    {
        AnimationState state;

        if (rigidBody.bodyType != RigidbodyType2D.Static)
        {
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
        } else
        {
            state = AnimationState.idle;
        }

        animator.SetInteger("State", ((int)state));
    }

    //boolean method to determine if player is on the ground
    private bool OnGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }
}
