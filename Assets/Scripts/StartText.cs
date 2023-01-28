using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public void LoadStartGame()
    {
        // Not currenlty using loading canvas, too fast!
        // Play a sound and then after a second load game? Use coroutines
        LoadManager.Instance.LoadSceneBackground("PlayTestArea");
    }
}
