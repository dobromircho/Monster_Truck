using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class SetupLocalPlayer : NetworkBehaviour
{
    public GameObject cam;

    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<CarUserControl>().enabled = true;
            GetComponent<CarController>().enabled = true;
            GetComponent<CarAudio>().enabled = true;
            GetComponent<CarSelfRighting>().enabled = true;
            GetComponent<AudioSource>().enabled = true;
            cam.SetActive(true);
        }
    }
    
}
