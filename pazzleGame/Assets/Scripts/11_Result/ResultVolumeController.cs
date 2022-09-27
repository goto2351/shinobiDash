using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audioオブジェクトに付けて読み込み時に音量を調節する
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class ResultVolumeController : Config
{
    
    // Start is called before the first frame update
    void Start()
    {
        float volumeCoeff = Config.volumeCoeff;
        gameObject.GetComponent<AudioSource>().volume = 0.3f * volumeCoeff;
    }
}
