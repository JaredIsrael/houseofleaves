using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: SO representing and storing lines of text that are simply displayed on
screen.

Author: Jared Israel

 */

[CreateAssetMenu(fileName = "New Monolog", menuName = "Monolog")]
public class MonologLines : ScriptableObject
{
    public string[] lines;

}
