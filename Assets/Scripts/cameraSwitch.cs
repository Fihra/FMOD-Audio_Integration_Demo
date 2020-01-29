using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{

    public Camera mainCam;
    public Camera skyCam;
    public Camera skyCam2;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    camera = GetComponent<Camera>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    private void Start()
    {
        skyCam.enabled = false;
        skyCam2.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Cube_ChangeView1")
        {
            mainCam.enabled = false;
            skyCam.enabled = true;
            Debug.Log(skyCam.enabled);
            //Debug.Log("Adjust Camera");
        }
        if(other.gameObject.name == "Cube_ChangeView2")
        {
            mainCam.enabled = false;
            skyCam.enabled = false;
            skyCam2.enabled = true; 
        }
    }
}
