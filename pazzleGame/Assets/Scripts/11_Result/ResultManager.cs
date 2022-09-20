using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : Config
{
    public GameObject gameOverObj;

    // Twitter�����N���J���֐�
#if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);
#else
    private static void OpenNewTab(string url) => Application.OpenURL(url);
#endif

    // ���g���C�{�^�����������Ƃ��ɖ{�҂̃V�[�������[�h����
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SCENE_NAME_FIELD);
    }

    // �u���ʂ��c�C�[�g�v�{�^�����������Ƃ���Twitter���e�����N���J��
    public void OpenTweetSubmitForm()
    {
        string tweetText = "�c�C�[�g�e�X�g ����: " + System.Math.Round(current_distance, 2) + " km";
        string linkURL = "https://www.yahoo.co.jp/";
        var URL = new System.Uri("https://twitter.com/intent/tweet?text=" + tweetText + "&url=" + linkURL);
        //Debug.Log(URL.AbsoluteUri);
        OpenNewTab(URL.AbsoluteUri);

    }
}
