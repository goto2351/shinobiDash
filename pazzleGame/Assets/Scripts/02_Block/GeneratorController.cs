using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 各GeneratorのGameObjectの変数を管理・変更するスクリプト
public class GeneratorController : Config
{
    public GUIUpdate guiUpdate;
    // レベルアップの表示時間
    float showLevelUpTime = 2.0f;

    public GameObject Base;
    public GameObject House;
    public GameObject SmallBuild;
    public GameObject Building;
    public GameObject Store;
    public GameObject CloudA;

    public int Level1;
    public int Level2;
    public int Level3;

    BlockGenerator baseGenerator;
    BlockGenerator houseGenerator;
    BlockGenerator smallBuildGenerator;
    BlockGenerator buildingGenerator;
    BlockGenerator storeGenerator;
    BlockGenerator cloudAGenerator;

    // Start is called before the first frame update
    void Start()
    {
        baseGenerator = Base.GetComponent<BlockGenerator>();
        houseGenerator = House.GetComponent<BlockGenerator>();
        smallBuildGenerator = SmallBuild.GetComponent<BlockGenerator>();
        buildingGenerator = Building.GetComponent<BlockGenerator>();
        storeGenerator = Store.GetComponent<BlockGenerator>();
        cloudAGenerator = CloudA.GetComponent<BlockGenerator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 1段階目(更新処理は一回のみ)
        if (current_distance  >= Level1 && Level1 != 0)
        {
            baseGenerator.paceContorller(2);
            storeGenerator.paceContorller(15, 1, 2, 1, 1);
            block_speed_relative = (10/6);
            Level1 = 0;
            // 指定時間レベルアップを表示する
            guiUpdate.LevelUp(showLevelUpTime);
        }

        // 2段階目(更新処理は一回のみ)
        if (current_distance  >= Level2 && Level2 != 0)
        {
            baseGenerator.paceContorller(100, 40, 50, 5, 15);
            smallBuildGenerator.paceContorller(100, 10, 20, 1, 2);
            block_speed_relative = 2f;
            Level2 = 0;
            // 指定時間レベルアップを表示する
            guiUpdate.LevelUp(showLevelUpTime);
        }

        // 2段階目(更新処理は一回のみ)
        if (current_distance  >= Level3 && Level3 != 0)
        {
            baseGenerator.paceContorller(100, 20, 30, 3, 7);
            buildingGenerator.paceContorller(100, 5, 10, 1, 1);
            block_speed_relative = 2.5f;
            Level3 = 0;
            // 指定時間レベルアップを表示する
            guiUpdate.LevelUp(showLevelUpTime, true);
        }

    }
}
