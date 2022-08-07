using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 各GeneratorのGameObjectの変数を管理・変更するスクリプト
public class GeneratorController : Config
{
    public GameObject Base;
    public GameObject House;
    public GameObject SmallBuild;

    public int Level1;
    public int Level2;

    private bool level1Used;
    private bool level2Used;

    BlockGenerator baseGenerator;
    BlockGenerator houseGenerator;
    BlockGenerator smallBuildGenerator;

    // Start is called before the first frame update
    void Start()
    {
        baseGenerator = Base.GetComponent<BlockGenerator>();
        houseGenerator = House.GetComponent<BlockGenerator>();
        smallBuildGenerator = SmallBuild.GetComponent<BlockGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        // 1段階目(更新処理は一回のみ)
        if (!level1Used)
        {
            if (current_distance >= Level1)
            {
                baseGenerator.paceContorller(2);
                level1Used = true;
            }
        }

        // 2段階目(更新処理は一回のみ)
        if (!level2Used)
        {
            if (current_distance >= Level2)
            {
                baseGenerator.paceContorller(10, 3, 5, 5, 8);
                smallBuildGenerator.paceContorller(100, 10, 20, 1, 2);
                level2Used = true;
            }
        }


    }
}
