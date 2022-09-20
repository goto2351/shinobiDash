using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : Config
{
    public GameObject BGMManager;
    public GameObject SEManager;

    private void Start()
    {
        float volumeCoeff = Config.volumeCoeff;
        BGMManager.GetComponent<AudioSource>().volume = 0.1f * volumeCoeff;
        SEManager.GetComponent<AudioSource>().volume = 0.2f * volumeCoeff;
    }

}
