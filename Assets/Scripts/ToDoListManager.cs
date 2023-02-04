using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private void Start()
    {
        isListRaised = false;
        foreach (TMP_Text text in ObjectiveTexts)
        {
            text.gameObject.SetActive(false);
        }
        currentTasks = new List<string>();
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

    IEnumerator AnimateList(bool up)
    {
        float elapsedTime = 0f;
        float percentComplete = 0f;
        float duration = 0.4f;
        Vector3 startPos = ToDoListObj.transform.position;
        Vector3 goalPos = startPos;
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
    }

}
