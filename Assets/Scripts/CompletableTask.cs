using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: This class represents a task that can be completed and needs to be
tracked for game progression. This can be a puzzle, a daily task, or anything
else. It has a description that can be used for debug use and also by the
to do list. It also has a UnityEvent that can be subscribed to by anyone for
when it is completed.

Author: Jared Israel 

 */

public abstract class CompletableTask : MonoBehaviour
{
    // Event for completion
    public string description;
    public UnityEvent TaskCompletedEvent;

}
