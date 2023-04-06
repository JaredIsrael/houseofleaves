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
}
