using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;


/*
 * PassageGenerator class. The purpose of this class is to choose the passage 
 * in which the user will be typing during the game. In addition, the class
 * contains a method to choose the next word up to type. This is done by keeping
 * track of an index, which is to be reset after the end of the passage has been
 * reached.
 */

public class PassageGenerator : MonoBehaviour
{
    public static int currentIndex = 0;
    private static string nextWord;
    private FallTimer fallTimer;

    private static string[] passage1 = { "Today", "is", "our", "first", "day",
        "back", "to", "work.", "I've", "noticed" , "there", "are", "some", "strange",
        "things","happening", "in", "this", "house.", "It", "could", "all", "just",
        "be", "in", "my", "head,", "but", "things", "don't", "seem", "right", "since",
        "that", "day..." };

    private static string[] passage2 = { "Alright", "day", "two...", "It", "feels",
        "like", "this", "house", "got", "smaller", "over", "night.", "Maybe", "I",
        "am", "going", "crazy.", "To", "be", "fair,", "I", "didn't", "get", "much",
        "sleep", "last", "night.", "Hopefully", "tonight", "is", "better." };

    private static string[] passage3 = { "What", "is", "the", "big", "deal", "about",
        "this", "key?", "Ugh", "can", "not", "even", "focus", "on", "work", "anymore.",
        "Do", "I", "even", "want", "to", "find", "the", "key...", "do", "I", "even", "want",
        "to", "go", "in?", "I", "do", "miss", "her...", "want", "to", "remember..."};

    private static string[] passage4 = { "Maybe", "I", "should", "have", "taken", "more",
        "time", "off.", "I", "think", "calling", "in", "sick", "tomorrow", "would", "be", "for",
        "the", "best.", "That", "dream", "was", "the", "worst", "one", "yet.", "But", "now",
        "I", "have", "the", "key!", "No...", "I", "can't", "go", "in", "her", "room...", "I",
        "shouldn't..." };

    private static string[][] passageList = { passage1, passage2, passage3, passage4 };

    private void Start()
    {
        currentIndex = 0;
    }


    /*
     * This method chooses a random passage from the above list. This is the 
     * passage that the user will have to type during the game.
     */
    public static string[] GetPassage()
    {
        //chooses passage from the list that corresponds to the level
        string[] passage = passageList[WorkPuzzle.level - 1];
       
        return passage;
    }

    /*
     * This method gets the next word of the passage. 
     */
    public static string GetNextWord(string[] passage)
    {
        if (currentIndex < passage.Length)
        {
            nextWord = passage[currentIndex];
            currentIndex++;

            return nextWord;
        }
        else
        {//user has typed full passage, switch to next level

            //completed code, should not be added to words list
            return "COMPLETE";
        }
    }
}
