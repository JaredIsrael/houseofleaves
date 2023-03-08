using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnText : MonoBehaviour
{
    public GameObject text;
    public Transform canvas;
    public GameObject workCanvas;
    public GameObject loseText;
    public WordDisplay Spawn()
    {
        GameObject textObject;
        //Vector3 position = new Vector3(Random.Range(90f, 900f), 500f);
        Vector3 position = new Vector3(Random.Range(90f, Screen.width-90f), Screen.height);

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
            loseText.SetActive(true);

            //TO-DO: get "return" to restart game after losing
            if (Input.GetKeyDown(KeyCode.Return))
            {
                loseText.SetActive(false);

                //reset variables
                PassageGenerator.currentIndex = 0;
                PassageGenerator.levelUp = false;
                FallTimer.stop = false;
                WorkPuzzle.gameOver = false;
            }

            //"escape" to quit the game after losing
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                loseText.SetActive(false);

                //game over, enable user input
                InputManager.inputActions.Enable();
                InputManager.UIActions.Enable();

                //reset variables
                PassageGenerator.currentIndex = 0;
                PassageGenerator.levelUp = false;

                WorkManager.words.Clear();

                workCanvas.SetActive(false);
            }
        }
    }
}
