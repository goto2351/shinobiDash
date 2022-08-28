using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // ブロック生成位置(X座標)
    public const float DefaultPosX = 17.0f;
    // ブロック生成位置(Y座標)(基本的に初期配置に使う)
    public const float DefaultPosY = -3.0f;

    // ブロックの削除される位置を指定
    public const float DestroyPositionX = -15.0f;

    // 画面表示する距離をいい感じのスケールに変換する
    public const float DistanceScale = 0.1f;

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
    public static float can_construct_line;
    // ゲームオーバーフラグ
    public static bool is_game_over;
     // 最後のBaseブロックの生成位置
     public static float last_base_block_point;
    // Baseブロックの生成フラグ
    public static bool is_generate_base_block;
    // ブロック移動速度の倍率
    public static float block_speed_relative;

    // static変数の初期化
    public void Initialize()
    {
        current_distance = 0;
        current_life = 3;
        can_construct_line = 0f;
        is_game_over = false;
        last_base_block_point = 0f;
        is_generate_base_block = false;
        block_speed_relative = 1.0f;
    }

    // TODO 後で消す
    public void log(string s)
    {
        Debug.Log(s);
    }

}
