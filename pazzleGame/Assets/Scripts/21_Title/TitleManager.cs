using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : Config
{
    //[SerializeField] private GameObject canvas_Title;
    [SerializeField] private GameObject canvas_HowtoPlay;
    [SerializeField] private Slider slider;
    // �X�^�[�g�{�^���������ꂽ�Ƃ��ɖ{�҂̃V�[����ǂݍ���

    void Awake()
    {
        Initialize();
    }

    public void LoadFieldScene()
    {
        SceneManager.LoadScene(SCENE_NAME_FIELD);
    }

    // �u�����т����v�{�^���������ꂽ���V�ѕ���\������
    public void ShowHowtoPlay()
    {
        canvas_HowtoPlay.SetActive(true);
    }

    // �V�ѕ���ʂŁu���ǂ�v�{�^���������ꂽ���V�ѕ����\���ɂ���
    public void HideHowtoPlay()
    {
        canvas_HowtoPlay.SetActive(false);
    }

    // ���ʂ̕ω���ϐ��ɔ��f������
    public void ChangeVolume()
    {
        volumeCoeff = slider.value / 10;

        gameObject.GetComponent<AudioSource>().volume = 0.2f * volumeCoeff;
        gameObject.GetComponent<SEMNG>().SEAttack();
    }
}
