using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spRenderer;
    public static bool fly;

    void Start()
    {
        fly = false;
    }

    void Update()
    {
        animator.SetBool("Fly", fly);
        if (fly)
        {
            spRenderer.flipX = true;
        } else
        {
            spRenderer.flipX = false;
        }
    }
}
