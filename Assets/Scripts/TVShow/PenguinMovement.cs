using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spRenderer;
    private float speed = 1.5f;
    public static bool jump;

    private void Start()
    {
        jump = false;
    }

    void Update()
    {
        //penguin jumps when the bool is set true
        animator.SetBool("Jump", jump);
        jump = false;
           
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        //penguin can move left/right (2D movement) using A/left arrow and D/right arrow
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walkleft"))
        {
            spRenderer.flipX = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walkright"))
        {
            spRenderer.flipX = false;
        }

        transform.position += horizontal * Time.deltaTime * speed;
    }
}