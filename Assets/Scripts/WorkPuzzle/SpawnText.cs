using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnText : MonoBehaviour
{
    public GameObject text;
    public Transform canvas;

    public WordDisplay Spawn()
    {
        Vector3 position = new Vector3(Random.Range(-1f,1f), 1f); 

        GameObject textObject = Instantiate(text, position, Quaternion.identity, canvas);
        WordDisplay display = textObject.GetComponent<WordDisplay>();

        return display;
    }
}
