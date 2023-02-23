using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*

Purpose: This script is responsible for displaying lines on the screen. It animates
lines, plays the appropriate sounds, and handles getting question input. 

Author: Jared Israel

 */

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text dialogTextMesh;
    [SerializeField]
    private Image dialogPanel;
    public static DialogManager Instance;
    private bool doneDisplayingText = false;
    private bool skip = false;
    [SerializeField]
    private float TEXT_CHARACTER_DELAY = 0.03f;
    [SerializeField]
    private AudioSource toggleSound;
    [SerializeField]
    private AudioSource writing;
    [SerializeField]
    private CanvasGroup choiceButtons;
    [SerializeField]
    private RectTransform defaultPanelPos;
    [SerializeField]
    private RectTransform highPanelPos;
    [SerializeField]
    private PlayerController pc;

    [SerializeField]
    private TMP_Text leftButtonText;

    [SerializeField]
    private TMP_Text rightButtonText;

    private IEnumerator panelFade;

    private int buttonClicked = 0;

    private const float PANEL_ANIM_DURATION = 1f;

    public delegate void DialogChoiceFunc();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            dialogPanel.GetComponent<CanvasGroup>().alpha = 0f;
            dialogPanel.gameObject.SetActive(false);
            choiceButtons.alpha = 0f;
            choiceButtons.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DisplayMonologLines(MonologLines monologLines)
    {
        dialogPanel.gameObject.SetActive(true);
        if (monologLines.lines.Length <= 0) return;
        StartCoroutine(ChangePanelVisibility(true));
        StartCoroutine(SlowDisplayMonolog(monologLines.lines));
    }

    // Hardcode keyboard space bar is easy to get working, but should be remapped later
    private IEnumerator SlowDisplayMonolog(string[] text)
    {
        toggleSound.Play();
        doneDisplayingText = false;
        StartCoroutine(MonitorForSkip());
        for (int i = 0; i < text.Length; i++)
        {
            writing.Play();
            skip = false;
            dialogTextMesh.text = "";

            int charLength = text[i].Length;
            for (int j = 0; j < charLength; j++)
            {
                dialogTextMesh.text = dialogTextMesh.text + text[i][j];
                if (skip)
                {
                    skip = false;
                    dialogTextMesh.text = text[i];
                    writing.Stop();
                    break;
                }
                yield return new WaitForSeconds(TEXT_CHARACTER_DELAY);
            }
            writing.Stop();

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                //Wait for go to next line
                yield return null;
            }
        }
        doneDisplayingText = true;
        toggleSound.Play();
        dialogPanel.gameObject.SetActive(false);

    }

    public void SlowDisplayBinaryQuestionLines(BinaryQuestionLines bqLines, DialogChoiceFunc left, DialogChoiceFunc right)
    {
        if (panelFade != null)
        {
            StopCoroutine(panelFade);
        }
        else
        {
            StartCoroutine(ChangePanelVisibility(true));
        }
        dialogPanel.gameObject.SetActive(true);
        if (bqLines.prambleLines.Length <= 0) return;
        leftButtonText.text = bqLines.leftPrompt;
        rightButtonText.text = bqLines.rightPrompt;
        StartCoroutine(SlowDisplayBinaryQuestion(bqLines.prambleLines, left, right));
    }

    // may god have mercy on this method
    // i am so tired
    private IEnumerator SlowDisplayBinaryQuestion(string[] text, DialogChoiceFunc left, DialogChoiceFunc right)
    {


        toggleSound.Play();
        doneDisplayingText = false;
        StartCoroutine(MonitorForSkip());
        for (int i = 0; i < text.Length; i++)
        {
            writing.Play();
            skip = false;
            dialogTextMesh.text = "";

            if (i == text.Length - 1)
            {
                pc.LockCamera();
                choiceButtons.gameObject.SetActive(true);
                StartCoroutine(AnimatePanel(true));
                StartCoroutine(ChangeButtonVisibility(true));
            }

            int charLength = text[i].Length;
            for (int j = 0; j < charLength; j++)
            {
                dialogTextMesh.text = dialogTextMesh.text + text[i][j];
                if (skip)
                {
                    skip = false;
                    dialogTextMesh.text = text[i];
                    writing.Stop();
                    break;
                }
                yield return new WaitForSeconds(TEXT_CHARACTER_DELAY);
            }
            writing.Stop();
            if (i < text.Length - 1)
            {
                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    //Wait for go to next line
                    yield return null;
                }
            }
        }

        buttonClicked = 0;
        while (buttonClicked == 0)
        {
            yield return null;
        }
        pc.UnLockCamera();
        StartCoroutine(ChangeButtonVisibility(false));
        panelFade = ChangePanelVisibility(false);
        StartCoroutine(panelFade);
        StartCoroutine(AnimatePanel(false));

        doneDisplayingText = true;
        toggleSound.Play();

        if (buttonClicked < 0)
        {
           
            left.Invoke();
        }
        else
        {
            right.Invoke();
        }

    }

    public void clickLeft()
    {
        buttonClicked = -1;
    }

    public void clickRight()
    {
        buttonClicked = 1;
    }

    private IEnumerator MonitorForSkip()
    {
        while (!doneDisplayingText)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                skip = true;
            }
            yield return null;
        }
    }

    // Use coroutines in order to animate smoothly without having an update method
    private IEnumerator AnimatePanel(bool up)
    {
        float elapsedTime = 0f;
        float percentComplete = 0f;
        float duration = PANEL_ANIM_DURATION;
        Vector3 startPos = dialogPanel.transform.position;
        Vector3 goalPos = up ? highPanelPos.position : defaultPanelPos.position;
        while (dialogPanel.transform.position != goalPos)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / duration;
            dialogPanel.transform.position = Vector3.Lerp(startPos, goalPos, percentComplete);
            yield return null;
        }
    }

    private IEnumerator ChangeButtonVisibility(bool visible)
    {
        float elapsedTime = 0f;
        float percentComplete = 0f;
        float duration = PANEL_ANIM_DURATION;
        float goalAlpha = visible ? 1f : 0f;
        while(choiceButtons.alpha!= goalAlpha)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / duration;
            choiceButtons.alpha = visible ? percentComplete : (1 - percentComplete);
            yield return null;
        }
        if(!visible) choiceButtons.gameObject.SetActive(false);
    }

    private IEnumerator ChangePanelVisibility(bool visible)
    {
        float elapsedTime = 0f;
        float percentComplete = 0f;
        float duration = PANEL_ANIM_DURATION;
        float goalAlpha = visible ? 1f : 0f;
        CanvasGroup panelGroup = dialogPanel.GetComponent<CanvasGroup>();
        while (panelGroup.alpha != goalAlpha)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / duration;
            panelGroup.alpha = visible ? percentComplete : (1 - percentComplete);
            yield return null;
        }
        if(!visible) dialogPanel.gameObject.SetActive(false);
    }
}
