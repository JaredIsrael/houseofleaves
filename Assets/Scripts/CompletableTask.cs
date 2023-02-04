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
    // Description of event, usually displayed in to do list
    public string description;
    /*

    There is probably a better way to do this, but tasks broadcast to a lot of
    places when they are finished, but some classes like the objectives manager
    and to-do list manager subscribe to a lot of different task's completion
    events, so by passing itself with the event (this event will usually be
    invoked with 'this' as param), the classes that listen to multiple tasks
    can tell which one was completed.

     */
    public UnityEvent<CompletableTask> TaskCompletedEvent;

}
