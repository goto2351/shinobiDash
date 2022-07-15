using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // ブロック生成位置(X座標)
    public const float DefaultPosX = 12.0f;
    // ブロック生成位置(Y座標)(基本的に初期配置に使う)
    public const float DefaultPosY = -4.0f;

    // ブロックの削除される位置を指定
    public const float DestroyPositionX = -12.0f;

    public static float Currentdistance = 0;
    public static int CurrentLife = 3;
}
