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

    private float blockSpeedX;
    private float width;
    private float height;
    // 生成ペースを管理する内部カウンター
    private float paceCount = 0;
    private float currentPace; 
    //　生成ブロック数を管理する内部カウンター
    private int chainCount = 0;
    private int chainMax = 1;
    // ベースタイルを何枚分連続で生成しなかったかのカウンタ
    private int skipBase = 0;

    // 生成ペースを動的に変更する
    public void paceContorller(float pace) 
    {
        GeneratePace = pace;
        IsGenerateRandom = false;
        //速度変更時の穴を消す
        if (IsBase)
        {
            paceCount = 0;
        }

        ResetChain();
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
        // 相対的なブロック速度を取得
        blockSpeedX = BlockSpeedX * block_speed_relative;

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
            paceCount = blockSpeedX;
        }
        // ブロック連続数を定義
        ResetChain();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 相対的なブロック速度を取得
        blockSpeedX = BlockSpeedX * block_speed_relative;
        // ゲームオーバー時処理を止める
        if (!is_game_over)
            {
            // 定期的にブロックを生成する
            if (paceCount >= width)
            {   
                
                // ベースオブジェクトである、建設可能位置にある、空中に生成されるオブジェクトである、のいずれか
                if (IsBase ||
                    (current_distance >= can_construct_line && current_distance < last_base_block_point - width * BlockScale * 0.2) ||
                    IsAir)
                {
                    if (IsBase)
                    {
                        BlockGenerate();
                        last_base_block_point = current_distance + (width * BlockScale);
                        can_construct_line = Mathf.Max(can_construct_line, current_distance);
                        skipBase = 0;
                    }
                    else if (IsAir)
                    {
                        BlockGenerate();
                    }
                    else if (current_distance > can_construct_line)
                    {
                        // 上手く絞り込めなかったので上限追加（崖ギリギリの表示をなくすためにwidthを若干引く）
                        if (current_distance < last_base_block_point - width * BlockScale * 0.1)
                        {
                            BlockGenerate();
                            // 次にブロック生成可能な位置を設定する
                            can_construct_line = Mathf.Max(can_construct_line, 
                                    current_distance + (width * BlockScale) * block_speed_relative * 0.9f);
                            is_generate_base_block = true;
                        }
                    }

                    chainCount++;
                    // 連続配置が終了するか判定
                    if (chainCount >= chainMax && (!IsBase || !is_generate_base_block))
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
                        // ベースが作られていないとき上物も配置しない
                        if (IsBase)
                        {
                            is_generate_base_block = false;
                        }

                    }
                }
            }

            // ベースが作られていないとき上物も配置しない
            if (IsBase)
            {
                if (current_distance >= last_base_block_point + (width * BlockScale * skipBase))
                {
                    skipBase++;
                    // 次にブロック生成可能な位置を設定する
                    can_construct_line = Mathf.Max(can_construct_line, last_base_block_point + (width * BlockScale * skipBase));

                }

            }
            
        }

        // 生成カウントを進める
        if (IsGenerateRandom &&  currentPace >= GenerateRateMin)
        {
            // 定義した範囲内で生成ペースを積み上げていく（上限は未満でややこしいので+1している）
            paceCount += blockSpeedX * Random.Range(GenerateRateMin, GenerateRateMax + 1) / currentPace;
        }
        else
        {
            paceCount += blockSpeedX / currentPace;
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
        Vector3 pos = new Vector3(posX + width / 2, posY - height / 2);
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
