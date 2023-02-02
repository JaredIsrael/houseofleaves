using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Duplicated code with other toggle buttons, careful

public class ScreenShakeToggle : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ssText;

    public void Start()
    {
        // Get default value from OptionsManager, init the text to match set value

    }

    public void ToggleSubtitles()
    {
        // Hard coded use of "on" string, if we change to t/f, this breaks! 
        bool isSsOn = ssText.text.ToLower().Equals("on");
        OptionsManager.EditBoolOption(OptionsManager.BoolOptions.ScreenShakeEnabled, !isSsOn);
        if (isSsOn)
        {
            ssText.text = "Off";
        }
        else
        {
            ssText.text = "On";
        }
    }
}
