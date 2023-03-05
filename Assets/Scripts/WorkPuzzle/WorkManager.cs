using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkManager : MonoBehaviour
{
    public List<Word> words;
    string[] passage;

    private bool wordIsActive;
    private Word activeWord;

    public SpawnText spawnText;

    public GameObject sliderBar;

    float increment;

    public static int completeCount;

    public void Start()
    {
        completeCount = 0;
        sliderBar.GetComponent<Image>().color = Color.green;
        increment = 1.0f / FallTimer.passage.Length;
    }

    /*
     * Creates a new word using the words from the randomly selected passage, 
     * and spawns the word to the screen
     */
    public void NewWord(string[] passage)
    {
        WordDisplay display = spawnText.Spawn();

        Word word = new Word(PassageGenerator.GetNextWord(passage), display);
        Debug.Log(word.word);
        words.Add(word);
    }


    /*
     * Tracks the characters being typed on words "active" on the screen
     */
    public void TypeKey(char key)
    {
        if (wordIsActive)
        {
            if (activeWord.GetNextChar() == key)
            {//progress bar is green is correct letter typed
                sliderBar.GetComponent<Image>().color = Color.green;
                activeWord.TypeChar();
            }
            else
            {//slider goes red to represent mistyped key
                sliderBar.GetComponent<Image>().color = Color.red;
            }
        } else
        {
            foreach (Word word in words)
            {
                if (word.GetNextChar() == key)
                {//progress bar is green is correct letter typed
                    sliderBar.GetComponent<Image>().color = Color.green;
                    activeWord = word;
                    wordIsActive = true;
                    word.TypeChar();
                    break;
                }
                else
                {//slider goes red to represent mistyped key
                    sliderBar.GetComponent<Image>().color = Color.red;
                }
            }
        }

        //word has finished being typed, can be removed from list of words
        if (wordIsActive && activeWord.WordComplete())
        {
            //a completed word means incrementing the progress bar, done here
            ProgressHandler.value += increment;
            wordIsActive = false;
            words.Remove(activeWord);
        }
    }

}
