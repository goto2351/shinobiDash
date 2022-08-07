using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigChara : Config
{
    // これ未満だとゲームオーバーとなるY軸の座標
    public const float GameOverLineY = -6.0f;

    // 被ダメージ後の無敵時間
    public const float MutekiTime = 1.0f;
    // 被ダメージフラグ
    public static bool IsDamaged = false;

}
