using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is to be attached to any colliders in the scene
//in which you wish the player to interact with and recieve a message

public class ReminderTrigger : MonoBehaviour
{
    [SerializeField] private GameObject reminder;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DisplayTime());
    }

    //displays the message to the player for 5 seconds, then disappears
    private IEnumerator DisplayTime()
    {
        reminder.SetActive(true);
        yield return new WaitForSeconds(5);
        reminder.SetActive(false);
    }
}
