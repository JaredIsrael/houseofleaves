using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;

    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas loadingCanvas;
    [SerializeField] private Slider loadingBar;
    
    void Start()
    {
        loadingCanvas.enabled = false;
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

   public void LoadSceneBackground(string sceneName)
    {
        menuCanvas.enabled = false;
        loadingCanvas.enabled = true;
        StartCoroutine(Waiting(sceneName));
    }

    IEnumerator Waiting(string sceneName)
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Loading(sceneName));
    }

    IEnumerator Loading(string sceneName)
    {
        AsyncOperation sceneOp = SceneManager.LoadSceneAsync(sceneName);
        
        while(!sceneOp.isDone)
        {
            float progress = Mathf.Clamp01(sceneOp.progress/.9f);
            loadingBar.value = progress;
            yield return null;
        }

    }

}
