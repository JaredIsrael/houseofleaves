using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] dialog;

    private int index;

    private float speed = 0.05f;

    private void Start()
    {
        StartDialog();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Continue();
        }
    }

    public void StartDialog()
    {
        StartCoroutine(TypeDialog());
    }

    private IEnumerator TypeDialog()
    {
        foreach(char letter in dialog[index].ToCharArray())
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
        } else
        {
            Destroy(transform.gameObject);
        }

    }
}
