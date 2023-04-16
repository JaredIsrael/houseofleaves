using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    [SerializeField] AudioSource song;
    [SerializeField] float bpm;
    [SerializeField] string[] notes;
    [SerializeField] PianoController pianoController;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject oldText;
    [SerializeField] GameObject newText;
    private float length;
    private bool alreadyPlayed;
    private float alpha;

    private void Start()
    {
        length = song.clip.length;
        alreadyPlayed = false;
        alpha = 1.0f;  
        StartCoroutine(CheckForCorrectInputs());
    }

    private IEnumerator CheckForCorrectInputs()
    {
        while (!pianoController.CheckForCorrectInputs(notes))
        {
            yield return false;
        }
        song.Play();
        alreadyPlayed = true;
        StartCoroutine(ChangeEnvironment());
        StopCoroutine(CheckForCorrectInputs());
    }

    private IEnumerator ChangeEnvironment()
    {
        Renderer renderer = wall.GetComponent<Renderer>();

        oldText.SetActive(false);
        newText.SetActive(true);
        wall.GetComponent<AudioSource>().Play();
        while (renderer.material.color.a > 0)
        {
            yield return new WaitForSeconds(0.2f);
            alpha -= 0.02f;
            renderer.material.color = new Color(1, 1, 1, alpha);
        }
        renderer.material.SetColor("_Color", new Color(1, 1, 1, 0));
        wall.SetActive(false);
        StopCoroutine(ChangeEnvironment());
    }
}
