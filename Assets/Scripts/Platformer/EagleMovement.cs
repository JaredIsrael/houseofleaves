using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spRenderer;
    public static bool fly;

    // Start is called before the first frame update
    void Start()
    {
        fly = false;
    }

    // Update is called once per frame
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
