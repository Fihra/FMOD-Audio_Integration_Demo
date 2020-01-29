using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersByID : MonoBehaviour
{
    FMOD.Studio.EventInstance music;

    FMOD.Studio.EventInstance playJumpSound;

    /*----------------Music Control--------------*/

    //Water Layer
    FMOD.Studio.EventDescription musicDescription;
    FMOD.Studio.PARAMETER_DESCRIPTION triggerMusic;
    FMOD.Studio.PARAMETER_ID pID;

    //Water Layer
    FMOD.Studio.PARAMETER_DESCRIPTION secondTrigger;
    FMOD.Studio.PARAMETER_ID pTwoID;

    //To Sky
    FMOD.Studio.PARAMETER_DESCRIPTION transitionTrigger;
    FMOD.Studio.PARAMETER_ID tranID;

    //Sky Layer
    FMOD.Studio.PARAMETER_DESCRIPTION skyTrigger2;
    FMOD.Studio.PARAMETER_ID skyID;

    //Sky To Lava Layer
    FMOD.Studio.PARAMETER_DESCRIPTION toMainTrigger;
    FMOD.Studio.PARAMETER_ID toMainID;

    /*-------------------------------------------*/
    /*----------------SFX Control----------------*/
    FMOD.Studio.EventDescription soundDescription;
    FMOD.Studio.PARAMETER_DESCRIPTION playSFX;
    FMOD.Studio.PARAMETER_ID sfxID;



    /*-------------------------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music 2D");
        music.start();

        musicDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Music 2D");

        playJumpSound = FMODUnity.RuntimeManager.CreateInstance("event:/Jump_Sound");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "waterTrigger") 
        {
            musicDescription.getParameterDescriptionByName("Water", out triggerMusic);
            pID = triggerMusic.id;

            music.setParameterByID(pID, 1.00f);
        }

        if(other.tag == "caveTrigger")
        {
            musicDescription.getParameterDescriptionByName("Ground", out triggerMusic);
            pID = triggerMusic.id;
            musicDescription.getParameterDescriptionByName("Near Lava", out secondTrigger);
            pTwoID = secondTrigger.id;

            music.setParameterByID(pID, 1.00f);
            music.setParameterByID(pTwoID, 0.00f);

        }

        if (other.tag == "lavaTrigger")
        {
            musicDescription.getParameterDescriptionByName("Ground", out triggerMusic);
            pID = triggerMusic.id;
            musicDescription.getParameterDescriptionByName("Near Lava", out secondTrigger);
            pTwoID = secondTrigger.id;

            musicDescription.getParameterDescriptionByName("To Main", out toMainTrigger);
            toMainID = toMainTrigger.id;

            music.setParameterByID(toMainID, 1.00f);
            music.setParameterByID(tranID, 0.00f);

            music.setParameterByID(pID, 1.00f);
            music.setParameterByID(pTwoID, 1.00f);
        }

        if (other.tag == "skyTrigger")
        {
            musicDescription.getParameterDescriptionByName("To Sky", out transitionTrigger);
            tranID = transitionTrigger.id;
            musicDescription.getParameterDescriptionByName("Sky Ver 2", out skyTrigger2);
            skyID = skyTrigger2.id;


            music.setParameterByID(toMainID, 0.00f);
            music.setParameterByID(skyID, 0.00f);

            music.setParameterByID(tranID, 1.00f);
        }

        if(other.name == "Cube_ChangeView2")
        {
            musicDescription.getParameterDescriptionByName("Sky Ver 2", out skyTrigger2);
            skyID = skyTrigger2.id;

            music.setParameterByID(skyID, 1.00f);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Water Music" || other.name == "Cave Music" || other.name == "Lava Music")
        {
            musicDescription.getParameterDescriptionByName("Main", out triggerMusic);
            music.setParameterByID(pID, 0.00f);
        }

    }
}
