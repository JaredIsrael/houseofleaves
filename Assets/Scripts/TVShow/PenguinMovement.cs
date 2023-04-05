using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spRenderer;
    private float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        //penguin can move left/right (2D movement) using A/D/left key/right key
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("penguin_walkleft"))
        {
            spRenderer.flipX = true;
        } else
        {
            spRenderer.flipX = false;
        }

        transform.position += horizontal * Time.deltaTime * speed;

    }
}
