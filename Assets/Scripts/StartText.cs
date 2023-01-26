using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public void LoadStartGame()
    {
        // Not currenlty using loading canvas, too fast!
        LoadManager.Instance.LoadSceneBackground("PlayTestArea");
    }
}
