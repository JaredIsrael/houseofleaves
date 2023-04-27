using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WordDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    //speed in which the text will fall down the screen
    private float speed = .15f * Screen.height;

    //list of words on the screen
    public GameObject[] words;

    private WorkManager workManager;

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
        if (transform.position.y > 0)
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        } else if (transform.position.y <= 0)
        {
            GameObject[] words = GameObject.FindGameObjectsWithTag("Word");
            //sets the boolean in fall timer to true, as the words have run off the screen
            FallTimer.stop = true;

            //reset the active words index to 0
            WorkManager.activeWord.WordReset();

            WorkManager.words.Clear();

            foreach (GameObject word in words)
            {
                Destroy(word);
            }
            ProgressHandler.value = 0f;
        }
    }
}
