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
    // スタートボタンが押されたときに本編のシーンを読み込む

    void Awake()
    {
        Initialize();
    }

    public void LoadFieldScene()
    {
        SceneManager.LoadScene(SCENE_NAME_FIELD);
    }

    // 「あそびかた」ボタンが押された時遊び方を表示する
    public void ShowHowtoPlay()
    {
        canvas_HowtoPlay.SetActive(true);
    }

    // 遊び方画面で「もどる」ボタンが押された時遊び方を非表示にする
    public void HideHowtoPlay()
    {
        canvas_HowtoPlay.SetActive(false);
    }

    // 音量の変化を変数に反映させる
    public void ChangeVolume()
    {
        volumeCoeff = slider.value / 10;

        gameObject.GetComponent<AudioSource>().volume = 0.2f * volumeCoeff;
        gameObject.GetComponent<SEMNG>().SEAttack();
    }
}
