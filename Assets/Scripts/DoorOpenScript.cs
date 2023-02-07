using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anime;
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Player")
         
        {
            anime.SetBool("openBool", true);
        }
        
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Player")

        {
            anime.SetBool("openBool", false);
        }
    }
}
