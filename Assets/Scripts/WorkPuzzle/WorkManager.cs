using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkManager : MonoBehaviour
{
    public static List<Word> words;
    string[] passage;

    private bool wordIsActive;
    private Word activeWord;

    public SpawnText spawnText;

    public GameObject sliderBar;

    public void Start()
    {
        words = new List<Word>();
        sliderBar.GetComponent<Image>().color = Color.clear;
    }

    /*
     * Creates a new word using the words from the randomly selected passage, 
     * and spawns the word to the screen
     */
    public void NewWord(string[] passage)
    {
        string newWord = PassageGenerator.GetNextWord(passage);

        if (!newWord.Equals("COMPLETE"))
        {
            WordDisplay display = spawnText.Spawn();
            Word word = new Word(newWord, display);
            words.Add(word);
        }
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
            {
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
                {
                    sliderBar.GetComponent<Image>().color = Color.red;
                }
            }
        }

        //word has finished being typed, can be removed from list of words
        if (wordIsActive && activeWord.WordComplete())
        {
            //a completed word means incrementing the progress bar, done here
            ProgressHandler.value += (1.0f / FallTimer.passage.Length);
            wordIsActive = false;
            words.Remove(activeWord);

            //all words in passage have been typed
            if (words.Count < 1 && PassageGenerator.currentIndex >= FallTimer.passage.Length)
            {
                //stop the coroutine from generating words on the screen
                FallTimer.stop = true;

                //Invoke task complete
                WorkPuzzle.gameOver = true;

                //TO-DO: this is where user levels up
                PassageGenerator.level++;
                PassageGenerator.currentIndex = 0;
                PassageGenerator.levelUp = true;
            }
        } else if (!activeWord.WordComplete() && FallTimer.stop)
        {
            activeWord.WordReset();
            wordIsActive = false;
        }
    }
}
