using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AllTasksCompletedEvent = new UnityEvent();
        // TaskAddedEvent = new UnityEvent<CompletableTask>();
        currentTasks = new List<CompletableTask>();
    }

    public void AddObjective(CompletableTask newTask)
    {
        currentTasks.Add(newTask);
        newTask.TaskCompletedEvent.AddListener(CompleteObjective);
        TaskAddedEvent.Invoke(newTask);
    }

    public void CompleteObjective(CompletableTask completed)
    {
        currentTasks.Remove(completed);
        if(currentTasks.Count <= 0)
        {
            AllTasksCompletedEvent.Invoke();
        }
    }
}
