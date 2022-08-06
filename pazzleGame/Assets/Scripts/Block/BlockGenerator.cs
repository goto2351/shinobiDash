using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : Config
{
    public GameObject BlockA;

    // ブロック生成位置下限(Y座標)
    public float DefaultMinPosY = 0.0f;
    // ブロック生成位置上限(Y座標)
    public float DefaultMaxPosY = 0.0f;
    // ブロックの生成間隔(大きいほど遅い)
    public float GeneratePace = 1;
    // ブロックの生成ランダム(最大最小)
    public bool IsGenerateRandom = false;
    public int GenerateRateMin = 1;
    public int GenerateRateMax = 1;
    //生成時のブロック個数
    public int GenerateBlocksMin = 1;
    public int GenerateBlocksMax = 1;

    // ブロックの流れる速度を指定(処理内で符号は反転するため、左方向を正とする)
    public float BlockSpeedX = 0.1f;
    // 開始時にこのブロックを作るか
    public bool IsStartGenerate = false;
    //このブロックが基準の足場か
    public bool IsBase = false;
    //このブロックが空中に配置されるものか
    public bool IsAir = false;

    private float width;
    private float height;
    // 生成ペースを管理する内部カウンター
    private float paceCount = 0;
    private float currentPace; 
    //　生成ブロック数を管理する内部カウンター
    private int chainCount = 0;
    private int chainMax = 1;

    // 生成ペースを動的に変更する
    public void paceContorller(float pace) 
    {
        GeneratePace = pace;
        IsGenerateRandom = false;
    }
    public void paceContorller(float pace, int rateMin, int rateMax, int blocksMin, int blocksMax)
    {
        GeneratePace = pace;
        IsGenerateRandom = true;
        GenerateRateMin = rateMin;
        GenerateRateMax = rateMax;
        GenerateBlocksMin = blocksMin;
        GenerateBlocksMax = blocksMax;
        // ブロック連続数を定義
        ResetChain();
    }


    // Start is called before the first frame update
    void Start()
    {
        //横幅を取得
        width = BlockA.GetComponent<SpriteRenderer>().bounds.size.x;
        //高さを取得
        height = BlockA.GetComponent<SpriteRenderer>().bounds.size.y;

        if (IsStartGenerate)
        {
            float generatePos = DestroyPositionX;
            // 初期ブロックを生成
            while (generatePos <= DefaultPosX)
            {
                BlockGenerate(generatePos, false);
                // ブロックの幅分ずらす
                generatePos += width;
            }
            // ずれを補正
            paceCount = BlockSpeedX;
        }
        // ブロック連続数を定義
        ResetChain();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 定期的にブロックを生成する
        if (paceCount >= width)
        {
            if (IsBase || CanConstruct || IsAir)
            {
                BlockGenerate();
                CanConstruct = IsBase;

                chainCount++;
                // 連続配置が終了するか判定
                if (chainCount >= chainMax)
                {
                    // カウントをリセット
                    paceCount = 0;
                    // ブロック連続数を再定義
                    ResetChain();
                }
                else
                {
                    // カウントをリセット
                    paceCount = 0;
                    currentPace = 1;
                }      
            }      

        }
        else
        {
            // ベースが作られていないとき上物も配置しない
            if (IsBase)
            {
                CanConstruct = false;
            }
        }


        // 生成カウントを進める
        if (IsGenerateRandom &&  currentPace >= GenerateRateMin)
        {
            // 定義した範囲内で生成ペースを積み上げていく（上限は未満でややこしいので+1している）
            paceCount += BlockSpeedX * Random.Range(GenerateRateMin, GenerateRateMax + 1) / currentPace;
        }
        else
        {
            paceCount += BlockSpeedX / currentPace;
        }
        
    }

    // ブロック生成処理
    void BlockGenerate(float posX = DefaultPosX, bool randFlag = true)
    {
        float posY = DefaultPosY;

        // ブロック生成のY軸をブレさせる
        if (randFlag)
        {
            posY = Random.Range(DefaultMinPosY, DefaultMaxPosY);
        }
        // 生成位置を指定
        Vector3 pos = new Vector3(posX + height / 2, posY - width / 2);
        // 生成処理
        GameObject obj = Instantiate(BlockA, pos, Quaternion.identity);
        BlockMover mover = obj.GetComponent<BlockMover>();
        mover.BlockSpeedX= BlockSpeedX;
    }

    public void ResetChain()
    {
        chainCount = 0;
        // 定義した範囲内で何個ブロックを連続されるか（上限は未満でややこしいので+1している）
        chainMax = Random.Range(GenerateBlocksMin, GenerateBlocksMax + 1);
        //生成ペースをリセット
        currentPace = GeneratePace;
    }

}
