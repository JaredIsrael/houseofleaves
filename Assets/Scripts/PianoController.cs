using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PianoController : MonoBehaviour
{
    public AudioSource pianoSource;
    public AudioClip[] noteClips;

    /*public void EnableActions()
    {
        InputManager.ToggleActionMap(InputManager.inputActions.Piano);
        InputManager.inputActions.Piano.C3.performed += ctx => PlayC3();
        InputManager.inputActions.Piano.CS3.performed += ctx => PlayCS3();
        InputManager.inputActions.Piano.D3.performed += ctx => PlayD3();
        InputManager.inputActions.Piano.DS3.performed += ctx => PlayDS3();
        InputManager.inputActions.Piano.E3.performed += ctx => PlayE3();
        InputManager.inputActions.Piano.F3.performed += ctx => PlayF3();
        InputManager.inputActions.Piano.FS3.performed += ctx => PlayFS3();
        InputManager.inputActions.Piano.G3.performed += ctx => PlayG3();
        InputManager.inputActions.Piano.GS3.performed += ctx => PlayGS3();
        InputManager.inputActions.Piano.A3.performed += ctx => PlayA3();
        InputManager.inputActions.Piano.AS3.performed += ctx => PlayAS3();
        InputManager.inputActions.Piano.B3.performed += ctx => PlayB3();
        InputManager.inputActions.Piano.C4.performed += ctx => PlayC4();
        InputManager.inputActions.Piano.CS4.performed += ctx => PlayCS4();
        InputManager.inputActions.Piano.D4.performed += ctx => PlayD4();
        InputManager.inputActions.Piano.DS4.performed += ctx => PlayDS4();
        InputManager.inputActions.Piano.E4.performed += ctx => PlayE4();
        InputManager.inputActions.Piano.F4.performed += ctx => PlayF4();
        InputManager.StopPlayerMovement();
    }

    public void DisableActions()
    {
        InputManager.ToggleActionMap(InputManager.inputActions.Player);
        InputManager.inputActions.Piano.C3.performed -= ctx => PlayC3();
        InputManager.inputActions.Piano.CS3.performed -= ctx => PlayCS3();
        InputManager.inputActions.Piano.D3.performed -= ctx => PlayD3();
        InputManager.inputActions.Piano.DS3.performed -= ctx => PlayDS3();
        InputManager.inputActions.Piano.E3.performed -= ctx => PlayE3();
        InputManager.inputActions.Piano.F3.performed -= ctx => PlayF3();
        InputManager.inputActions.Piano.FS3.performed -= ctx => PlayFS3();
        InputManager.inputActions.Piano.G3.performed -= ctx => PlayG3();
        InputManager.inputActions.Piano.GS3.performed -= ctx => PlayGS3();
        InputManager.inputActions.Piano.A3.performed -= ctx => PlayA3();
        InputManager.inputActions.Piano.AS3.performed -= ctx => PlayAS3();
        InputManager.inputActions.Piano.B3.performed -= ctx => PlayB3();
        InputManager.inputActions.Piano.C4.performed -= ctx => PlayC4();
        InputManager.inputActions.Piano.CS4.performed -= ctx => PlayCS4();
        InputManager.inputActions.Piano.D4.performed -= ctx => PlayD4();
        InputManager.inputActions.Piano.DS4.performed -= ctx => PlayDS4();
        InputManager.inputActions.Piano.E4.performed -= ctx => PlayE4();
        InputManager.inputActions.Piano.F4.performed -= ctx => PlayF4();
        InputManager.StartPlayerMovement();
    }*/

    public void PlayC3()
    {
        pianoSource.clip = noteClips[0];
        pianoSource.Play();
    }

    public void PlayCS3()
    {
        pianoSource.clip = noteClips[1];
        pianoSource.Play();
    }

    public void PlayD3()
    {
        pianoSource.clip = noteClips[2];
        pianoSource.Play();
    }

    public void PlayDS3()
    {
        pianoSource.clip = noteClips[3];
        pianoSource.Play();
    }

    public void PlayE3()
    {
        pianoSource.clip = noteClips[4];
        pianoSource.Play();
    }

    public void PlayF3()
    {
        pianoSource.clip = noteClips[5];
        pianoSource.Play();
    }

    public void PlayFS3()
    {
        pianoSource.clip = noteClips[6];
        pianoSource.Play();
    }

    public void PlayG3()
    {
        pianoSource.clip = noteClips[7];
        pianoSource.Play();
    }

    public void PlayGS3()
    {
        pianoSource.clip = noteClips[8];
        pianoSource.Play();
    }

    public void PlayA3()
    {
        pianoSource.clip = noteClips[9];
        pianoSource.Play();
    }

    public void PlayAS3()
    {
        pianoSource.clip = noteClips[10];
        pianoSource.Play();
    }

    public void PlayB3()
    {
        pianoSource.clip = noteClips[11];
        pianoSource.Play();
    }

    public void PlayC4()
    {
        pianoSource.clip = noteClips[12];
        pianoSource.Play();
    }

    public void PlayCS4()
    {
        pianoSource.clip = noteClips[13];
        pianoSource.Play();
    }

    public void PlayD4()
    {
        pianoSource.clip = noteClips[14];
        pianoSource.Play();
    }

    public void PlayDS4()
    {
        pianoSource.clip = noteClips[15];
        pianoSource.Play();
    }

    public void PlayE4()
    {
        pianoSource.clip = noteClips[16];
        pianoSource.Play();
    }

    public void PlayF4()
    {
        pianoSource.clip = noteClips[17];
        pianoSource.Play();
    }

}
