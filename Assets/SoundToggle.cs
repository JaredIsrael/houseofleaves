using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Duplicated code with other toggle buttons, careful

public class SoundToggle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text soundText;

    public void Start()
    {
        // Get default value from OptionsManager, init the text to match set value

    }

    public void ToggleSound()
    {
        // Hard coded use of "on" string, if we change to t/f, this breaks! 
        bool isSoundOn = soundText.text.ToLower().Equals("on");
        OptionsManager.EditBoolOption(OptionsManager.BoolOptions.SoundEnabled, !isSoundOn);
        if (isSoundOn)
        {
            soundText.text = "Off";
        }
        else
        {
            soundText.text= "On";
        }
    }
}
