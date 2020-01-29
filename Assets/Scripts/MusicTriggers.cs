using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggers : MonoBehaviour
{
    private FMOD.Studio.EventInstance music;
    private FMOD.Studio.PARAMETER_DESCRIPTION musicParameter;
    private FMOD.Studio.PARAMETER_ID pID;

    [FMODUnity.EventRef]
    public string fmodEvent;


    // Start is called before the first frame update
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        music.start();
    }


}
