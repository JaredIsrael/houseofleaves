using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI watermelonText;
    [SerializeField] private AudioSource collectSound;

    private int watermelonCount;
    private int noWatermelon;

    private void Start()
    {
        watermelonCount = 0;
        noWatermelon = GameObject.FindGameObjectsWithTag("Watermelon").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Watermelon"))
        {
            collectSound.Play();
            collision.gameObject.SetActive(false);
            watermelonCount++;
            watermelonText.SetText("Watermelon: " + watermelonCount + "/" + noWatermelon);
        }
    }
}
