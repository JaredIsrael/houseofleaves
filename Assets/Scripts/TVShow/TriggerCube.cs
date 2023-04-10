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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Eagle talks here");

        bubble.SetActive(true);
        StartCoroutine(TypeDialog());
    }

    private void Start()
    {
        //StartCoroutine(TypeDialog());
    }

    private void Update()
    {
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

    private IEnumerator TypeDialog()
    {
        foreach (char letter in dialog[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    private void Continue()
    {
        if (index < dialog.Length - 1)
        {
            index++;

            text.text = string.Empty;
            StartCoroutine(TypeDialog());
        }
        else
        {
            Destroy(bubble);
        }

    }
}
