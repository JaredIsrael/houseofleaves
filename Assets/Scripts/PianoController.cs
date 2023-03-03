using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PianoController : MonoBehaviour
{
    public AudioSource[] pianoSources;
    public AudioClip[] noteClips;
    [HideInInspector]
    public PianoActions inputActions;

    private void Awake()
    {
        inputActions = new PianoActions();
        SetUpContexts();
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

    public void PlayC3()
    {
        Debug.Log("Tried to Play C3");
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[0];
        pianoSources[index].Play();
    }

    public void PlayCS3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[1];
        pianoSources[index].Play();
    }

    public void PlayD3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[2];
        pianoSources[index].Play();
    }

    public void PlayDS3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[3];
        pianoSources[index].Play();
    }

    public void PlayE3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[4];
        pianoSources[index].Play();
    }

    public void PlayF3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[5];
        pianoSources[index].Play();
    }

    public void PlayFS3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[6];
        pianoSources[index].Play();
    }

    public void PlayG3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[7];
        pianoSources[index].Play();
    }

    public void PlayGS3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[8];
        pianoSources[index].Play();
    }

    public void PlayA3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[9];
        pianoSources[index].Play();
    }

    public void PlayAS3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[10];
        pianoSources[index].Play();
    }

    public void PlayB3()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[11];
        pianoSources[index].Play();
    }

    public void PlayC4()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[12];
        pianoSources[index].Play();
    }

    public void PlayCS4()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[13];
        pianoSources[index].Play();
    }

    public void PlayD4()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[14];
        pianoSources[index].Play();
    }

    public void PlayDS4()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[15];
        pianoSources[index].Play();
    }

    public void PlayE4()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[16];
        pianoSources[index].Play();
    }

    public void PlayF4()
    {
        int index = FindAvailableSource();
        pianoSources[index].clip = noteClips[17];
        pianoSources[index].Play();
    }

    private int FindAvailableSource()
    {
        int available = 0;
        for (int i = 0; i < pianoSources.Length; i++) {
            if (!pianoSources[i].isPlaying)
            {
                available = i;
                break;
            }
        }
        return available;
    }

}
