using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private AudioSource deathSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerDie();
        }
    }

    //method disables player movement and plays death animation
    private void PlayerDie()
    {
        deathSound.Play();
        rigidBody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
    }

    //method restarts the scene (level) after dying
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
