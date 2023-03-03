using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnText : MonoBehaviour
{
    public GameObject text;
    public Transform canvas;

    public WordDisplay Spawn()
    {
        GameObject textObject;
        Vector3 position = new Vector3(Random.Range(-50f,50f), 52f);

        if (PassageGenerator.level % 2 == 0)
        { //TO-DO: create other level ideas.
            textObject = Instantiate(text, position, Quaternion.Euler(0,180,0), canvas);
        } else
        {
            textObject = Instantiate(text, position, Quaternion.identity, canvas);
        }
        WordDisplay display = textObject.GetComponent<WordDisplay>();

        return display;
    }

    private void Update()
    {
        if (FallTimer.stop)
        {
            //TO-DO: get "return" key to restart game
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PassageGenerator.currentIndex = 0;
                PassageGenerator.levelUp = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();

            }
        }
    }
}
