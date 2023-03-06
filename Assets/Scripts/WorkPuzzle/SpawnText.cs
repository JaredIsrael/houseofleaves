using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnText : MonoBehaviour
{
    public GameObject text;
    public Transform canvas;
    public GameObject workCanvas;

    public WordDisplay Spawn()
    {
        GameObject textObject;
        Vector3 position = new Vector3(Random.Range(90f, 900f), 500f);

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
            //TO-DO: get "return" to restart game after losing
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Destroy(GameObject.Find("LoseText(Clone)"));

                PassageGenerator.currentIndex = 0;
                PassageGenerator.levelUp = false;
                FallTimer.stop = false;
            }

            //"escape" to quit the game after losing
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(GameObject.Find("LoseText(Clone)"));

                InputManager.inputActions.Enable();
                InputManager.UIActions.Enable();

                PassageGenerator.currentIndex = 0;
                PassageGenerator.levelUp = false;
                workCanvas.SetActive(false);
            }
        }
    }
}
