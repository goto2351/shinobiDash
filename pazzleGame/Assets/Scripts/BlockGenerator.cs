using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject BlockA;
    // ブロック生成位置(X座標)
    public const float DefaultPosX = 10.0f;
    // ブロック生成位置(Y座標)(基本的に初期配置に使う)
    public const float DefaultPosY = -4.0f;
    // ブロック生成位置下限(Y座標)
    public float DefaultMinPosY = 0.0f;
    // ブロック生成位置上限(Y座標)
    public float DefaultMaxPosY = 0.0f;
    // ブロックの生成間隔(大きいほど遅い)
    public int GeneratePace = 3;

    private static  int generateCount;
    
    // Start is called before the first frame update
    void Start()
    {
        // 初期ブロックを生成
        for(int i = 0 ; i < 15;i++)
        {
            BlockGenerate(i - 5, false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        generateCount++;
        // 定期的にブロックを生成する
        if (generateCount >= GeneratePace)
        {
            BlockGenerate();
            generateCount = 0;
        }
    }

    // ブロック生成処理
    void BlockGenerate(float posX = DefaultPosX,bool randFlag = true)
    {
        float posY = DefaultPosY;

        // ブロック生成のY軸をブレさせる
        if (randFlag)
        {
            posY = Random.Range(DefaultMinPosY, DefaultMaxPosY);
        }
        // 生成位置を指定
        Vector3 pos = new Vector3(posX, posY);
        // 生成処理
        Instantiate(BlockA, pos, Quaternion.identity);
    }

}
