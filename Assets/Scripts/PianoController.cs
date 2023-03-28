using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PianoController : MonoBehaviour
{
    public AudioSource[] pianoSources;
    [HideInInspector]
    public PianoActions inputActions;
    private ArrayList playedNotes;

    private void Awake()
    {
        inputActions = new PianoActions();
        playedNotes = new ArrayList();
    }


    public void SetUpContexts()
    {
        inputActions.Play.C3.performed += ctx => PlayC3();
        inputActions.Play.CS3.performed += ctx => PlayCS3();
        inputActions.Play.D3.performed += ctx => PlayD3();
        inputActions.Play.DS3.performed += ctx => PlayDS3();
        inputActions.Play.E3.performed += ctx => PlayE3();
        inputActions.Play.F3.performed += ctx => PlayF3();
        inputActions.Play.FS3.performed += ctx => PlayFS3();
        inputActions.Play.G3.performed += ctx => PlayG3();
        inputActions.Play.GS3.performed += ctx => PlayGS3();
        inputActions.Play.A3.performed += ctx => PlayA3();
        inputActions.Play.AS3.performed += ctx => PlayAS3();
        inputActions.Play.B3.performed += ctx => PlayB3();
        inputActions.Play.C4.performed += ctx => PlayC4();
        inputActions.Play.CS4.performed += ctx => PlayCS4();
        inputActions.Play.D4.performed += ctx => PlayD4();
        inputActions.Play.DS4.performed += ctx => PlayDS4();
        inputActions.Play.E4.performed += ctx => PlayE4();
        inputActions.Play.F4.performed += ctx => PlayF4();
    }

    public void DeleteContexts()
    {
        inputActions.Play.C3.performed -= ctx => PlayC3();
        inputActions.Play.CS3.performed -= ctx => PlayCS3();
        inputActions.Play.D3.performed -= ctx => PlayD3();
        inputActions.Play.DS3.performed -= ctx => PlayDS3();
        inputActions.Play.E3.performed -= ctx => PlayE3();
        inputActions.Play.F3.performed -= ctx => PlayF3();
        inputActions.Play.FS3.performed -= ctx => PlayFS3();
        inputActions.Play.G3.performed -= ctx => PlayG3();
        inputActions.Play.GS3.performed -= ctx => PlayGS3();
        inputActions.Play.A3.performed -= ctx => PlayA3();
        inputActions.Play.AS3.performed -= ctx => PlayAS3();
        inputActions.Play.B3.performed -= ctx => PlayB3();
        inputActions.Play.C4.performed -= ctx => PlayC4();
        inputActions.Play.CS4.performed -= ctx => PlayCS4();
        inputActions.Play.D4.performed -= ctx => PlayD4();
        inputActions.Play.DS4.performed -= ctx => PlayDS4();
        inputActions.Play.E4.performed -= ctx => PlayE4();
        inputActions.Play.F4.performed -= ctx => PlayF4();
    }

    public void PlayC3()
    {
        pianoSources[0].Play();
        playedNotes.Add("C3");
    }

    public void PlayCS3()
    {
        pianoSources[1].Play();
        playedNotes.Add("CS3");
    }

    public void PlayD3()
    {
        pianoSources[2].Play();
        playedNotes.Add("D3");
    }

    public void PlayDS3()
    {
        pianoSources[3].Play();
        playedNotes.Add("DS3");
    }

    public void PlayE3()
    {
        pianoSources[4].Play();
        playedNotes.Add("E3");
    }

    public void PlayF3()
    {
        pianoSources[5].Play();
        playedNotes.Add("F3");
    }

    public void PlayFS3()
    {
        pianoSources[6].Play();
        playedNotes.Add("FS3");
    }

    public void PlayG3()
    {
        pianoSources[7].Play();
        playedNotes.Add("G3");
    }

    public void PlayGS3()
    {
        pianoSources[8].Play();
        playedNotes.Add("GS3");
    }

    public void PlayA3()
    {
        pianoSources[9].Play();
        playedNotes.Add("A3");
    }

    public void PlayAS3()
    {
        pianoSources[10].Play();
        playedNotes.Add("AS3");
    }

    public void PlayB3()
    {
        pianoSources[11].Play();
        playedNotes.Add("B3");
    }

    public void PlayC4()
    {
        pianoSources[12].Play();
        playedNotes.Add("C4");
    }

    public void PlayCS4()
    {
        pianoSources[13].Play();
        playedNotes.Add("CS4");
    }

    public void PlayD4()
    {
        pianoSources[14].Play();
        playedNotes.Add("D4");
    }

    public void PlayDS4()
    {
        pianoSources[15].Play();
        playedNotes.Add("DS4");
    }

    public void PlayE4()
    {
        pianoSources[16].Play();
        playedNotes.Add("E4");
    }

    public void PlayF4()
    {
        pianoSources[17].Play();
        playedNotes.Add("F4");
    }

    public bool CheckForCorrectInputs(string[] notes)
    {
        bool correct = false;
        if (playedNotes.Count < 2)
        {
            return correct;
        } 
        foreach (string note in notes)
        {
            if (note.Equals(playedNotes[playedNotes.Count - 1]) || note.Equals(playedNotes[playedNotes.Count - 2]))
            {
                correct = true;
            } else
            {
                correct = false;
            }

        }
        return correct;
    }

}
