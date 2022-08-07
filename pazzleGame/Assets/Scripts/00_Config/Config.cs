using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // ブロック生成位置(X座標)
    public const float DefaultPosX = 15.0f;
    // ブロック生成位置(Y座標)(基本的に初期配置に使う)
    public const float DefaultPosY = -4.0f;

    // ブロックの削除される位置を指定
    public const float DestroyPositionX = -15.0f;

    // タグ
    public const string TAG_NAME_ENEMY = "Enemy";
    public const string TAG_NAME_GROUND = "Ground";
    public const string TAG_NAME_PLAYER = "Player";

    // シーン名
    public const string SCENE_NAME_FIELD = "Field";
    public const string SCENE_NAME_GAMEOVER = "GameOver";

    /*  
     *  _/_/_/_/_/_/_/_/_/_/_/_/
     *  
     *      ↓static変数↓
     *      
     *  _/_/_/_/_/_/_/_/_/_/_/_/
     */

    // 現在の走行距離
    public static float current_distance;
    // 現在のプレイヤー体力(0以下になるとGAMEOVER) 
    public static int current_life;
    // 建物の自動生成フラグ
    public static bool can_construct;
    // ゲームオーバーフラグ
    public static bool is_game_over;

    // static変数の初期化
    public void Initialize()
    {
        current_distance = 0;
        current_life = 3;
        can_construct = true;
        is_game_over = false;
    }

    // TODO 後で消す
    public void log(string s)
    {
        Debug.Log(s);
    }

}
