using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject loseText;
    //speed in which the text will fall down the screen
    private float speed = 10f;

    private FallTimer fallTimer;

    //list of words on the screen
    public GameObject[] words;

    //public SpawnText spawnText;

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

    //TO-DO: keep track of a list of words in the Update rather than each having
    //their own update.
    private void FixedUpdate()
    {
        /*
        if (transform.position.y > -45)
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        } else if (transform.position.y <= -45)
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
        */
        
        words = GameObject.FindGameObjectsWithTag("Word");
        foreach(GameObject word in words)
        {
            if (word.transform.position.y > 0)
            {
                word.transform.Translate(0f, -speed * Time.deltaTime, 0f);
            }
            else if (word.transform.position.y <= 0)
            {
                //could i now just do this to get the words to stop generating?
                StopCoroutine(GameObject.Find("WorkManager").GetComponent<FallTimer>().GenerateWord());
                FallTimer.stop = true;
                foreach (GameObject deadWord in words)
                {
                    Destroy(deadWord);
                }
                Instantiate(loseText);
            }
            break;
        }
    }
}
