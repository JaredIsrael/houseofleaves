using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: SO representing a binary question with preamble lines and then two prompts.

Author: Jared Israel

 */

[CreateAssetMenu(fileName ="New Binary Question", menuName ="Binary Question")]
public class BinaryQuestionLines : ScriptableObject
{
    public string[] prambleLines;
    public string leftPrompt;
    public string rightPrompt;
}
