using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    [SerializeField] AudioSource song;
    [SerializeField] float bpm;
    [SerializeField] string[] notes;
    [SerializeField] PianoController pianoController;
    private float length;
    private bool alreadyPlayed;

    private void Start()
    {
        length = song.clip.length;
        alreadyPlayed = false;
    }

    private void Update()
    {
        bool correctNotes = pianoController.CheckForCorrectInputs(notes);
        if (correctNotes && !alreadyPlayed)
        {
            song.Play();
            alreadyPlayed = true;
            enabled = false;
        }
    }
}
