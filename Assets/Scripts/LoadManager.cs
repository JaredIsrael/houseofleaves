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
    [SerializeField] private GameObject loadingImages;

    void Start()
    {
        loadingCanvas.enabled = false;
        for(int i = 0; i < loadingImages.transform.childCount; i++)
        {
            loadingImages.transform.GetChild(i).gameObject.SetActive(false);
        }

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

        StartCoroutine(DisplayImages());
        StartCoroutine(Waiting(sceneName));
    }
    
    IEnumerator DisplayImages()
    {
        int randomImageIndex = Random.Range(0, loadingImages.transform.childCount);
        loadingImages.transform.GetChild(randomImageIndex).gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        loadingImages.transform.GetChild(randomImageIndex).gameObject.SetActive(false);
        randomImageIndex = Random.Range(0, loadingImages.transform.childCount);
        loadingImages.transform.GetChild(randomImageIndex).gameObject.SetActive(true);

        yield return null;
    }

    IEnumerator Waiting(string sceneName)
    {
        yield return new WaitForSeconds(7);
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
