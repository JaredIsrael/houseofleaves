using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    public void LoadStartGame()
    {
        LoadManager.Instance.LoadSceneBackground("PlayTestArea");
    }
}
