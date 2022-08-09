using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ゲーム全体を管理する処理を書くスクリプト
public class GameDirector : Config
{
    // ゲームオーバー表示までの時間
    public float displayDelay = 1.5f;
    // ゲームオーバー遷移までの時間
    public float gameOverDelay = 2.5f;
    // プレイヤーのコライダー
    public BoxCollider2D PLcollider;
    public BoxCollider2D PLcollider2;
    public GUIUpdate guiUpdate;
    bool gameOverFlg;

    // Start is called before the first frame update
    void Awake()
    {
        Initialize();
        ChangeColiderEnabled(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_life <= 0)
        {
            is_game_over = true;
        }

        if (is_game_over)
        {
            if (!gameOverFlg)
            {
                gameOverFlg = true;
                // プレイヤーの当たり判定をなくす
                ChangeColiderEnabled(false); 
                // 指定時間後ゲームオーバーを表示する
                guiUpdate.GameOver(displayDelay);
                // 指定時間後ゲームオーバーのシーン遷移
                Invoke(nameof(ChangeSceneGameOver), displayDelay + gameOverDelay);
            }
        }

    }
    // コライダーの有効判定を変更する
    void ChangeColiderEnabled(bool able)
    {       
        PLcollider.enabled = able;
        PLcollider2.enabled = able;
    }

    //シーンを変える
    void ChangeSceneGameOver()
    {
        SceneManager.LoadScene(SCENE_NAME_GAMEOVER);
    }
}
