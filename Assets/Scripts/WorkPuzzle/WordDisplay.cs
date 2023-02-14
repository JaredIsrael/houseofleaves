using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WordDisplay : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject loseText;
    //speed in which the text will fall down the screen
    private float speed = 10f;

    public SpawnText spawnText;

    public void SetText(string word)
    {
        text.text = word;
    }

    public void DeleteChar()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.green;
    }

    public void DeleteWord ()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.y <= -45)
        {
            GameObject[] words = GameObject.FindGameObjectsWithTag("Word");
            //sets the boolean in fall timer to true, as the words have run off the screen
            FallTimer.stop = true;
            foreach (GameObject word in words)
            {
                Destroy(word);
            }
            Instantiate(loseText);
        } 

        //TO-DO: get "return" key to restart game
        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("return");
            PassageGenerator.currentIndex = 0;
            PassageGenerator.levelUp = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        //GameObject[] words = GameObject.FindGameObjectsWithTag("Word");
        if (transform.position.y > -45)
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }
        /*
        else
        {
            //sets the boolean in fall timer to true, as the words have run off the screen
            FallTimer.stop = true;
            foreach (GameObject word in words)
            {
                Destroy(word);
            }
            Instantiate(loseText);
            //StartCoroutine(Pause);
            foreach(char key in Input.inputString)
            {
                if (key == '\n')
                {
                    Debug.Log("return");
                    PassageGenerator.currentIndex = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            
            //PassageGenerator.currentIndex = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        */
        
    }
}
