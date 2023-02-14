using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnText : MonoBehaviour
{
    public GameObject text;
    public Transform canvas;

    public WordDisplay Spawn()
    {
        GameObject textObject;
        Vector3 position = new Vector3(Random.Range(-50f,50f), 52f);

        if (PassageGenerator.level > 1)
        { //TO-DO: create other level ideas.
            textObject = Instantiate(text, position, Quaternion.Euler(0,180,0), canvas);
        } else
        {
            textObject = Instantiate(text, position, Quaternion.identity, canvas);
        }
        WordDisplay display = textObject.GetComponent<WordDisplay>();

        return display;
    }
}
