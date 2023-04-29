using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip startSound;

    public void LoadStartGame()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }

        audio.PlayOneShot(startSound, .5f);
        menuCanvas.enabled = false;
        LoadManager.Instance.LoadSceneBackground("Day1House");
    }
}
