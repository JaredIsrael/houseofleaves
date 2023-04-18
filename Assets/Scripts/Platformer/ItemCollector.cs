using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI watermelonText;
    private int watermelonCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Watermelon"))
        {
            collision.gameObject.SetActive(false);
            watermelonCount++;
            watermelonText.SetText("Watermelon: " + watermelonCount);
        }
    }
}