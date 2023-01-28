using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionsManager
{

    public enum BoolOptions
    {
        SoundEnabled,
        ScreenShakeEnabled,
        SubtitlesEnabled,
    }

    public enum FloatOptions
    {
        SoundLevel,
    }

    public static void EditBoolOption(BoolOptions option, bool value)
    {
        // Edit option in player prefs or wherever stored
    }

    public static void EditFloatOption(FloatOptions option, float value)
    {
        // Edit option 
    }

    public static bool GetBoolOption(BoolOptions option)
    {
        // Data drive this in player prefs, reference here, might need to be async
        return true;
    }

    public static float GetFloatOption(FloatOptions option)
    {
        // Data drive this in player prefs, reference here, might need to be async
        return 0f;
    }

}
