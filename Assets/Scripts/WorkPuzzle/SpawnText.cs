using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnText : MonoBehaviour
{
    public GameObject text;
    [SerializeField]
    private InputManager im;
    public Transform canvas;
    public GameObject workCanvas;
    public GameObject loseText;
    [SerializeField] 
    private MonologLines failureLines;
    public WordDisplay Spawn()
    {
        GameObject textObject;
        Vector3 position = new Vector3(Random.Range(90f, Screen.width-80f), Screen.height);

        //TO-DO: create other level ideas.
        if (PassageGenerator.level % 2 == 0)
        { //inverted text
            textObject = Instantiate(text, position, Quaternion.Euler(0,180,0), canvas);
        } else
        { //normal text
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

            //"return" to restart game after losing
            if (Input.GetKeyDown(KeyCode.Return))
            {
                loseText.SetActive(false);

                //reset variables
                FallTimer.delay = 1.5f;
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
                im.inputActions.Enable();
                InputManager.UIActions.Enable();

                //reset variables
                FallTimer.delay = 3f;
                PassageGenerator.currentIndex = 0;
                PassageGenerator.levelUp = false;

                WorkManager.words.Clear();

                workCanvas.SetActive(false);
                DialogManager.Instance.DisplayMonologLines(failureLines);
            }
        }
    }
}
