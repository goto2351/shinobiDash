using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : Config
{
    //[SerializeField] private GameObject canvas_Title;
    [SerializeField] private GameObject canvas_HowtoPlay;
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
}
