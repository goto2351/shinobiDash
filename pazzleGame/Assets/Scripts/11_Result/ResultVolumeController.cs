using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio�I�u�W�F�N�g�ɕt���ēǂݍ��ݎ��ɉ��ʂ𒲐߂���
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
