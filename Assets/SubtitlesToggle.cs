using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Duplicated code with other toggle buttons, careful

public class SubtitlesToggle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text subText;

    public void Start()
    {
        // Get default value from OptionsManager, init the text to match set value

    }

    public void ToggleSubtitles()
    {
        // Hard coded use of "on" string, if we change to t/f, this breaks! 
        bool isSubsOn = subText.text.ToLower().Equals("on");
        OptionsManager.EditBoolOption(OptionsManager.BoolOptions.SubtitlesEnabled, !isSubsOn);
        if (isSubsOn)
        {
            subText.text = "Off";
        }
        else
        {
            subText.text = "On";
        }
    }
}
