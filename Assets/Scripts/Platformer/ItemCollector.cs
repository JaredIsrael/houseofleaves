using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private AudioSource collectSound;

    [SerializeField] private GameObject contDialog;
    [SerializeField] private GameObject finalDialog;

    private int keyCount;
    private int noKeys;

    private void Start()
    {
        contDialog.SetActive(true);
        finalDialog.SetActive(false);
        keyCount = 0;
        noKeys = GameObject.FindGameObjectsWithTag("Key").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            collectSound.Play();
            collision.gameObject.SetActive(false);
            keyCount++;
            keyText.SetText("Keys: " + keyCount + "/" + noKeys);
            if (keyCount == noKeys)
            {
                contDialog.SetActive(false);
                finalDialog.SetActive(true);
            }
        }
    }
}
