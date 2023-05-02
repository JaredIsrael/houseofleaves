using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*

Purpose: This singleton class is intended to listen to the objectives manager
and manage the to do list internals and UI display. It keeps track of what
objectives the objectives manager says the player is currently doing and
crosses out items when the objective is complete by subscribing to the task
completion events. It keeps track of the to do list UI canvas, animating it and
changing the text to match the current objectives. Both this object and the
canvas persist between scenes with a DontDestroyOnLoad call.

Author: Jared Israel

 */

public class ToDoListManager : MonoBehaviour
{
    public static ToDoListManager Instance;
    [SerializeField]
    private GameObject ToDoListObj;
    [SerializeField]
    private List<TMP_Text> ObjectiveTexts;
    [SerializeField]
    private AudioSource openAudio;
    [SerializeField]
    private AudioSource closeAudio;
    private List<string> currentTasks;
    private bool isListRaised;
    private bool isAnimating = false;


    /*

    This portion of the initialization logic is done in the start method rather
    than awake because it needs the Objectives manager to be setup. The OM does
    its intstantiation in the awake call, so by calling on it in the start method
    which is always called after awake, we are sure the OM will be setup.

     */
    private void Start()
    {
        isListRaised = false;
        foreach (TMP_Text text in ObjectiveTexts)
        {
            text.gameObject.SetActive(false);
        }
        currentTasks = new List<string>();
        // We just wait for the OM to tell us the player is tracking a new objective
        ObjectivesManager.TaskAddedEvent.AddListener(AddTask);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AddTask(CompletableTask newTask)
    {
        currentTasks.Add("- "+newTask.description);
        RenderObjectives();
        // Listen for the completion event on the task the OM just told us to track
        newTask.TaskCompletedEvent.AddListener(CompleteTask);

    }

    private void CompleteTask(CompletableTask completedTask)
    {
        for (int i = 0; i < currentTasks.Count; i++)
        {
            if (ObjectiveTexts[i].text == "- "+completedTask.description)
            {
                ObjectiveTexts[i].fontStyle = FontStyles.Strikethrough;
            }
        }
    }

    private void RenderObjectives()
    {
        for (int i = 0; i < currentTasks.Count; i++)
        {
            ObjectiveTexts[i].gameObject.SetActive(true);
            ObjectiveTexts[i].text = currentTasks[i];
        }
    }

    public void ToggleList()
    {
        // Don't let the player do this while the animation is in progress!
        if (!isAnimating)
        {
            if (isListRaised)
            {
                PutDownList();
            }
            else
            {
                BringUpList();
            }
            isListRaised = !isListRaised;
        }
    }

    public void BringUpList()
    {
        openAudio.Play();
        StartCoroutine(AnimateList(true));
    }

    public void PutDownList()
    {
        closeAudio.Play();
        StartCoroutine(AnimateList(false));

    }

    // Use coroutines in order to animate smoothly without having an update method
    IEnumerator AnimateList(bool up)
    {
        float elapsedTime = 0f;
        float percentComplete = 0f;
        float duration = 0.4f;
        Vector3 startPos = ToDoListObj.transform.position;
        Vector3 goalPos = startPos;
        isAnimating = true;
        if (up)
        {
            goalPos += new Vector3(0, 270, 0);
        }
        else
        {
            goalPos += new Vector3(0, -270, 0);
        }

        while (ToDoListObj.transform.position != goalPos)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / duration;
            ToDoListObj.transform.position = Vector3.Lerp(startPos, goalPos, percentComplete);
            yield return null;
        }
        isAnimating = false;
    }

}
