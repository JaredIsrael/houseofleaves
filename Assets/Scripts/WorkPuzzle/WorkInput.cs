using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkInput : MonoBehaviour
{
    public WorkManager workManager;

    /*
     * Tracks the characters being clicked on the keyboard using an input string; 
     * characters are to be passed on to the TypeKey method of WorkManager
     */
    void Update()
    {
        foreach (char key in Input.inputString)
        {
            workManager.TypeKey(key);
        }
    }

    //Turn this update into coroutine so it can start/stop easily
    /*
    public IEnumerator KeyTracking()
    {
        //TO-DO: how to get this called every frame, like update?
        //tried while true, but unity crashed
        foreach (char key in Input.inputString)
        {
            workManager.TypeKey(key);
            yield return null;
        }
    }
    */
}
