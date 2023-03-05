using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script works along with WorkManager; updates the progress bar
 * each time a word has been fully typed.
 */

public class ProgressHandler : MonoBehaviour
{
    public Slider slider;
    //public Text percentage_txt;

    public static float value;

    IEnumerator Start()
    {
        slider.value = 0.0f;
        value = 0.0f;

        while (value <= 1.0f)
        {
            yield return new WaitForSeconds(0.5f);
            UpdateSlider(value);
        }

    }

    void UpdateSlider(float value)
    {
        slider.value = value;
        //percentage_txt.text = slider.value.ToString();
    }

}