using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//try deleting later
[System.Serializable]
public class Word
{
    public string word;

    private int wordIndex;

    private WordDisplay display;

    //constructor
    public Word(string newWord, WordDisplay newDisplay)
    {
        word = newWord;

        wordIndex = 0;

        display = newDisplay;

        display.SetText(word);
    }

    /*
     * Returns the next character/letter of the word being typed.
     */
    public char GetNextChar()
    {
        return word[wordIndex];
    }

    public void TypeChar()
    {
        wordIndex++;

        display.DeleteChar();
    }

    public bool WordComplete()
    {
        bool complete = (wordIndex >= word.Length);

        if (complete)
        {
            display.DeleteWord();
        }

        return complete;
    }
}
