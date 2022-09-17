using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigChara : Config
{
    // これ未満だとゲームオーバーとなるY軸の座標
    public const float GameOverLineY = -6.0f;

    // 攻撃の再入力までの時間
    public const float AttackedTime = 0.5f;
    // 攻撃フラグ
    public static bool IsAttacked = false;

    // 被ダメージ後の無敵時間
    public const float MutekiTime = 1.0f;
    // 被ダメージフラグ
    public static bool IsDamaged = false;
    // 回復後の再回復までの時間
    public const float HealedTime = 0.1f;
    // 被回復フラグ
    public static bool IsHealed = false;

}
