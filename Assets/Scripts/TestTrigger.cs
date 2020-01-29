using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    FMOD.Studio.EventInstance music;


    // Start is called before the first frame update
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music 2D");
        music.start();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            music.setParameterByName("Water", 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        float x = 0f;
        if(other.name == "Player")
        {
            music.setParameterByName("Water", x);
        }
    }
}
