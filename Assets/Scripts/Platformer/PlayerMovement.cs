using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(horizontal * 7f, rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 14f);
        }
    }
}
