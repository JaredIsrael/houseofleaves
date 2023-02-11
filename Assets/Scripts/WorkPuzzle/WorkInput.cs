using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkInput : MonoBehaviour
{
    public WorkManager workManager;

    // Update is called once per frame
    void Update()
    {
        foreach (char key in Input.inputString)
        {
            workManager.TypeKey(key);
        }
    }
}
