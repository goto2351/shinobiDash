using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : Config
{
    //[SerializeField] private GameObject canvas_Title;
    [SerializeField] private GameObject canvas_HowtoPlay;
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
}
