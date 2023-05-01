using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnText : MonoBehaviour
{
    public GameObject text;
    [SerializeField]
    private InputManager im;
    [SerializeField] private float speed;
    public Transform canvas;
    public GameObject workCanvas;
    public GameObject loseText;
    [SerializeField] 
    private MonologLines failureLines;
    private bool invert = false;

    public WordDisplay Spawn()
    {
        GameObject textObject;
        Vector3 position = new Vector3(Random.Range(90f, Screen.width-80f), Screen.height);

        if (WorkPuzzle.level < 3)
        { //days 1 and 2; normal text (just change speed)
            textObject = Instantiate(text, position, Quaternion.identity, canvas);
        } else if (WorkPuzzle.level == 3)
        { //day 3; inverted text
            textObject = Instantiate(text, position, Quaternion.Euler(0, 180, 0), canvas);
        }
        else
        { //day 4; alternates between normal and inverted text
            if (invert)
            {
                textObject = Instantiate(text, position, Quaternion.Euler(0, 180, 0), canvas);
                invert = !invert;
            } else
            {
                textObject = Instantiate(text, position, Quaternion.identity, canvas);
                invert = !invert;
            }
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
                FallTimer.delay = 2f;
                FallTimer.nextTime = 0f;
                PassageGenerator.currentIndex = 0;
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
                FallTimer.delay = speed;
                FallTimer.nextTime = 0f;
                PassageGenerator.currentIndex = 0;

                WorkManager.words.Clear();

                workCanvas.SetActive(false);
                DialogManager.Instance.DisplayMonologLines(failureLines);
            }
        }
    }
}
