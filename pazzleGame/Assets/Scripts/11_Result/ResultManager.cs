using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : Config
{
    public GameObject gameOverObj;

    // Twitterリンクを開く関数
#if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);
#else
    private static void OpenNewTab(string url) => Application.OpenURL(url);
#endif

    // リトライボタンを押したときに本編のシーンをロードする
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SCENE_NAME_FIELD);
    }

    // 「結果をツイート」ボタンを押したときにTwitter投稿リンクを開く
    public void OpenTweetSubmitForm()
    {
        string tweetText = "忍ダッシュ！で  " + System.Math.Round(current_distance, 2) + " km走りました！";
        string linkURL = "https://goto2351.github.io/shinobiDash_play/";
        var URL = new System.Uri("https://twitter.com/intent/tweet?text=" + tweetText + "&url=" + linkURL);
        //Debug.Log(URL.AbsoluteUri);
        OpenNewTab(URL.AbsoluteUri);

    }
}
