using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    public List<Word> words;
    string[] passage;

    private bool wordIsActive;
    private Word activeWord;

    public SpawnText spawnText;

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
            {
                activeWord.TypeChar();
            }
        } else
        {
            foreach (Word word in words)
            {
                if (word.GetNextChar() == key)
                {
                    activeWord = word;
                    wordIsActive = true;
                    word.TypeChar();
                    break;
                }
            }
        }

        if (wordIsActive && activeWord.WordComplete())
        { //word has finished being typed, can be removed from list of words
            wordIsActive = false;
            words.Remove(activeWord);
        }
    }

}
