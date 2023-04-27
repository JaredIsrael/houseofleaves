using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private AudioSource deathSound;

    [SerializeField] private GameObject talkTrigger1;
    [SerializeField] private GameObject eagle;

    private static bool sceneRestart = false;

    public void Start()
    {
        //if the scene has been restarted (i.e., player died), do not repeat text interaction
        if (sceneRestart)
        {
            //diable collider (trigger) so speech bubbles dont appear again
            talkTrigger1.SetActive(false);

            //set eagle to end position
            eagle.transform.position = new Vector3(269.5972f, 1.5f, 0f);
        }
    }

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
        sceneRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
