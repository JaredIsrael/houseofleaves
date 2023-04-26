using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private AudioSource collectSound;

    private int keyCount;
    private int noKey;

    private void Start()
    {
        keyCount = 0;
        noKey = GameObject.FindGameObjectsWithTag("Key").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            collectSound.Play();
            collision.gameObject.SetActive(false);
            keyCount++;
            keyText.SetText("Keys: " + keyCount + "/" + noKey);
        }
    }
}
