using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCube : MonoBehaviour
{
    [SerializeField] private GameObject Pbubble;
    [SerializeField] private TextMeshProUGUI Ptext;
    [SerializeField] private string[] penDialog;

    [SerializeField] private GameObject Ebubble;
    [SerializeField] private TextMeshProUGUI Etext;
    [SerializeField] private string[] eagleDialog;


    private int penIndex;
    private int eagleIndex;

    private float speed = 0.05f;

    private UnityEvent eagleTalk = new UnityEvent();
    private UnityEvent eagleFly = new UnityEvent();

    private void Start()
    {
        //new listener; used to determine when to start eagle response to penguin
        eagleTalk.AddListener(StartEagleDialog);
        eagleFly.AddListener(StartEagleFly);
    }

    //when penguin enters the trigger cube, bubble will appear
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Pbubble != null)
        {
            PenguinMovement.jump = true;
            Pbubble.SetActive(true);
            StartCoroutine(TypeDialog(penDialog, penIndex, Ptext));
        }
    }

    private void Update()
    {
       //avoids null reference errors after bubbles are removed from scene
        if (Ebubble != null && Pbubble != null)
        {
            //checks if the user has clicked the space bar to skip through text (while bubble is active)
            if (Input.GetKeyDown(KeyCode.Space) && Pbubble.activeSelf)
            {
                if (Ptext.text.Length < penDialog[penIndex].Length)
                {
                    StopAllCoroutines();
                    Ptext.text = penDialog[penIndex];
                }
                else
                {
                    PenContinue();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && Ebubble.activeSelf)
            {
                if (Etext.text.Length < eagleDialog[eagleIndex].Length)
                {
                    StopAllCoroutines();
                    Etext.text = eagleDialog[eagleIndex];
                }
                else
                {
                    EagleContinue();
                }
            }
        }
    }

    //co-routine to get a text typing effect in penguin speech bubbles
    private IEnumerator TypeDialog(string[] dialog, int index, TextMeshProUGUI text)
    {
        foreach (char letter in dialog[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    private void StartEagleDialog()
    {
        Ebubble.SetActive(true);
        StartCoroutine(TypeDialog(eagleDialog, eagleIndex, Etext));
    }

    private void StartEagleFly()
    {
        //TO-DO: create animation of eagle flying away from player
    }

    //TO-DO: combine continue methods into one

    //method to display all existing dialog in bubble, then destroy when done 
    private void PenContinue()
    {
        if (penIndex < penDialog.Length - 1)
        {//there is still more text to display
            penIndex++;

            Ptext.text = string.Empty;
            StartCoroutine(TypeDialog(penDialog, penIndex, Ptext));
        }
        else
        {//all dialog for bubble has been displayed
            Pbubble.SetActive(false);
            //when penguin is done talking, start eagle
            eagleTalk.Invoke();
        }
    }

    //method to display all existing dialog in bubble, then destroy when done 
    private void EagleContinue()
    {
        if (eagleIndex < eagleDialog.Length - 1)
        {//there is still more text to display
            eagleIndex++;

            Etext.text = string.Empty;
            StartCoroutine(TypeDialog(eagleDialog, eagleIndex, Etext));
        }
        else
        {//all dialog for both bubbles has been displayed
            Destroy(Pbubble);
            Destroy(Ebubble);

            //eagle flys away when interaction complete
            eagleFly.Invoke();
        }
    }
}