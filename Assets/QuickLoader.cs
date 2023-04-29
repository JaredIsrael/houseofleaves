using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickLoader : MonoBehaviour
{

    public static QuickLoader Instance;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void QuickLoadSceneAsync(string sceneName)
    {
        AsyncOperation sceneOp = SceneManager.LoadSceneAsync(sceneName);
    }
}
