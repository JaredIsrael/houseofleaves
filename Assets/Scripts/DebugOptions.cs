using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugOptions : MonoBehaviour
{
    public void DayOneLoad()
    {
        SceneManager.LoadSceneAsync("Day1House");
    }

    public void NightOneLoad()
    {
        SceneManager.LoadSceneAsync("NightOneScene");
    }
}
