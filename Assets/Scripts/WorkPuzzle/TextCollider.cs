using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCollider : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void LostGame()
    {
        Instantiate(text);
        Pause();
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(30.0f);
    }

}
