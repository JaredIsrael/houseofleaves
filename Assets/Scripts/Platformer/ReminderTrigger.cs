using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminderTrigger : MonoBehaviour
{
    [SerializeField] private GameObject reminder;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DisplayTime());
    }

    private IEnumerator DisplayTime()
    {
        reminder.SetActive(true);
        yield return new WaitForSeconds(5);
        reminder.SetActive(false);
    }
}
