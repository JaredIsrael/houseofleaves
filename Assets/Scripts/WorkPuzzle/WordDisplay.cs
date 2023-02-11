using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TextMeshPro text;
    public float speed = .015f;

    public void SetText(string word)
    {
        text.text = word;
    }

    public void DeleteChar()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.green;
    }

    public void DeleteWord ()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(0f, -speed*Time.deltaTime, 0f);
    }
}
