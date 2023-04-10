using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] dialog;

    private int index;

    private float speed = 0.05f;

    //when penguin enters the trigger cube, bubble will appear
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Eagle talks here");

        bubble.SetActive(true);
        StartCoroutine(TypeDialog());
    }

    private void Update()
    {
        //checks if the user has clicked the space bar to skip through text
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text.Length < dialog[index].Length)
            {
                StopAllCoroutines();
                text.text = dialog[index];
            }
            else
            {
                Continue();
            }
        }
    }

    //co-routine to get a type-text style in the speech bubbles
    private IEnumerator TypeDialog()
    {
        foreach (char letter in dialog[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    //method to display all existing dialog in bubble, then destroy when done 
    private void Continue()
    {
        if (index < dialog.Length - 1)
        {//there is still more text to display
            index++;

            text.text = string.Empty;
            StartCoroutine(TypeDialog());
        }
        else
        {//all dialog for bubble has been displayed
            Destroy(bubble);
        }

    }
}
