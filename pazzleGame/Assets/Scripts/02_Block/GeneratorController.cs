using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 各GeneratorのGameObjectの変数を管理・変更するスクリプト
public class GeneratorController : Config
{
    public GUIUpdate guiUpdate;
    // レベルアップの表示時間
    float showSpeedUpTime = 2.0f;

    public GameObject Base;
    public GameObject House;
    public GameObject SmallBuild;
    public GameObject Building;
    public GameObject Store;
    public GameObject CloudA;

    public GameObject EnemyGhost;
    public GameObject EnemyBat;
    public GameObject EnemyFire;

    public GameObject Heart;

    public int Level2;
    public int Level3;
    public int Level4;
    public int Level5;

    BlockGenerator baseGenerator;
    BlockGenerator houseGenerator;
    BlockGenerator smallBuildGenerator;
    BlockGenerator buildingGenerator;
    BlockGenerator storeGenerator;
    BlockGenerator cloudAGenerator;

    BlockGenerator ghostGenerator;
    BlockGenerator batGenerator;
    BlockGenerator fireGenerator;

    BlockGenerator HeartGenerator;

    // Start is called before the first frame update
    void Start()
    {
        baseGenerator = Base.GetComponent<BlockGenerator>();
        houseGenerator = House.GetComponent<BlockGenerator>();
        smallBuildGenerator = SmallBuild.GetComponent<BlockGenerator>();
        buildingGenerator = Building.GetComponent<BlockGenerator>();
        storeGenerator = Store.GetComponent<BlockGenerator>();
        cloudAGenerator = CloudA.GetComponent<BlockGenerator>();
        ghostGenerator = EnemyGhost.GetComponent<BlockGenerator>();
        batGenerator = EnemyBat.GetComponent<BlockGenerator>();
        fireGenerator = EnemyFire.GetComponent<BlockGenerator>();
        HeartGenerator = Heart.GetComponent<BlockGenerator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 1段階目(更新処理は一回のみ)
        if (current_distance  >= Level2 && Level2 != 0)
        {
            baseGenerator.paceContorller(2);
            smallBuildGenerator.paceContorller(100, 10, 20, 1, 1);
            storeGenerator.paceContorller(15, 1, 2, 1, 1);
            cloudAGenerator.paceContorller(40, 1, 2, 1, 2);
            block_speed_relative = 1.25f;
            // ゴーストの出現頻度微増
            ghostGenerator.paceContorller(120, 1, 5, 1, 2);
            Level2 = 0;
            // 指定時間レベルアップを表示する
            guiUpdate.SpeedUp(showSpeedUpTime);
        }

        // 2段階目(更新処理は一回のみ)
        if (current_distance  >= Level3 && Level3 != 0)
        {
            baseGenerator.paceContorller(100, 40, 50, 5, 15);
            // 炎が出現するようになる
            fireGenerator.paceContorller(80, 1, 2, 1, 1);
            block_speed_relative = 1.6667f;
            Level3 = 0;
            // 指定時間レベルアップを表示する
            guiUpdate.SpeedUp(showSpeedUpTime);
        }

        // 3段階目(更新処理は一回のみ)
        if (current_distance  >= Level4 && Level4 != 0)
        {
            baseGenerator.paceContorller(100, 30, 40, 5, 7);
            buildingGenerator.paceContorller(200, 5, 10, 1, 1);
            houseGenerator.paceContorller(100, 5, 10, 1, 2);
            cloudAGenerator.paceContorller(30, 1, 2, 1, 3);
            block_speed_relative = 2.0f;
            // ゴーストの出現頻度微増
            ghostGenerator.paceContorller(100, 1, 5, 1, 3);
            // 自機狙いのコウモリが出現するようになる
            batGenerator.paceContorller(150, 1, 3, 1, 1);
            // ハートの出現頻度をアップ
            HeartGenerator.paceContorller(600, 1, 3, 1, 1);
            Level4 = 0;
            // 指定時間レベルアップを表示する
            guiUpdate.SpeedUp(showSpeedUpTime);
        }

        // 4段階目(最終段階)
        if (current_distance >= Level5 && Level5 != 0)
        {
            baseGenerator.paceContorller(100, 20, 30, 3, 7);
            houseGenerator.paceContorller(100, 5, 10, 1, 2);
            storeGenerator.paceContorller(100, 2, 3, 1, 3);
            smallBuildGenerator.paceContorller(300, 8, 12, 1, 1);
            buildingGenerator.paceContorller(100, 10, 20, 1, 1);

            // 敵の出現頻度上昇
            ghostGenerator.paceContorller(100, 1, 5, 1, 4);
            fireGenerator.paceContorller(60, 1, 3, 1, 1);
            batGenerator.paceContorller(135, 1, 3, 1, 2);
            block_speed_relative = 2.5f;
            Level5 = 0;
            // 指定時間レベルアップを表示する
            guiUpdate.SpeedUp(showSpeedUpTime, true);
        }

    }
}
