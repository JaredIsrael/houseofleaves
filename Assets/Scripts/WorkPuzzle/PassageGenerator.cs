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
    public static int level = 1;
    public static bool levelUp = false;
    private static string nextWord;
    private FallTimer fallTimer;

    private static string[] passage1 = { "According", "to", "all", "known", "laws",
        "of", "aviation,", "there", "is", "no", "way", "that", "a", "bee",
        "should", "be", "able", "to", "fly." };

    private static string[] passage2 = { "Hello,", "this", "is", "a", "test.",
        "You", "need", "to", "do", "some", "very", "boring", "work.",
        "Make", "sure", "to", "complete", "your", "to-do", "list!" };

    private static string[] passage3 = { "My", "name", "is", "Ayumu", "and",
        "this", "is", "my", "game", "Dream", "Walker.", "You", "will",
        "see", "my", "many", "nightmares!" };

    private static string[][] passageList = { passage1, passage2, passage3 };

    //TO-DO: fill in with relevant passages that fit the days of the story.
    // no longer choose at random, passage # corresponds to the day.

    /*
     * This method chooses a random passage from the above list. This is the 
     * passage that the user will have to type during the game.
     */
    public static string[] GetPassage()
    {
        //chooses passage from the list that corresponds to the level
        string[] passage = passageList[level-1];

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
            level++;
            currentIndex = 0;
            levelUp = true;

            //TO-DO: stop displaying words to screen
            //StopCoroutine(GameObject.Find("WorkManager").GetComponent<FallTimer>().GenerateWord());

            return "done";
        }
    }
}
