using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: This class mangages the objectives for a given level. It will keep
track of the completable tasks that the player needs to do, and emit an event
when the player finishes everything. It is a singleton that persists between
scenes, so it should avoid referencing game objects in a scene.

Author: Jared Israel

 */
public class ObjectivesManager : MonoBehaviour
{
    public static ObjectivesManager Instance;
    public static UnityEvent AllTasksCompletedEvent;
    public static UnityEvent<CompletableTask> TaskAddedEvent;

    private List<CompletableTask> currentTasks;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AllTasksCompletedEvent = new UnityEvent();
            TaskAddedEvent = new UnityEvent<CompletableTask>();
            currentTasks = new List<CompletableTask>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddObjective(CompletableTask newTask)
    {
        currentTasks.Add(newTask);
        TaskAddedEvent.Invoke(newTask);
    }

    public void CompleteObjective(CompletableTask completed)
    {
        currentTasks.Remove(completed);
        completed.TaskCompletedEvent.Invoke();
        if(currentTasks.Count <= 0)
        {
            AllTasksCompletedEvent.Invoke();
        }
    }
}
