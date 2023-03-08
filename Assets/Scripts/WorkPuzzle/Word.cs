using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Word class. The purpose of this class is to make the construction of words
 * more efficient, as well as keep track of their contents. 
 */


//To-do: is this necessary?
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

    //Returns the next character/letter of the word being typed.
    public char GetNextChar()
    {
        return word[wordIndex];
    }

    //deletes the chars. from a word as they are being typed
    public void TypeChar()
    {
        wordIndex++;

        display.DeleteChar();
    }

    //Tracks whether a word has been completed using a boolean
    public bool WordComplete()
    {
        bool complete = (wordIndex >= word.Length);

        if (complete)
        {//deletes word from display
            display.DeleteWord();
        }

        return complete;
    }
}
