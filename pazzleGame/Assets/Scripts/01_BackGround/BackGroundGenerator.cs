using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : Config
{
    public GameObject backGround;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0.0f, 1.0f, 0.0f);
        // 生成処理
        Instantiate(backGround, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバー時処理を止める（処理入れるときはこの中に書くこと、今は不要なのでコメントアウト）
        // if (!is_game_over){
        // }
    }
}
