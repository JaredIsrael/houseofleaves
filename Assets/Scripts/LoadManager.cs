using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;

    [SerializeField] private Canvas loadingCanvas;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private GameObject loadingImages;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            loadingCanvas.enabled = false;
            for (int i = 0; i < loadingImages.transform.childCount; i++)
            {
                loadingImages.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void LoadSceneBackground(string sceneName)
    {
        loadingCanvas.enabled = true;

        //StartCoroutine(DisplayImages());
        StartCoroutine(Waiting(sceneName));
    }
    
    //Chooses random images to display while loading
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

    //Temporary function to display loading screen longer
    IEnumerator Waiting(string sceneName)
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(Loading(sceneName));
    }

    //Changes the value of the loading slider
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
