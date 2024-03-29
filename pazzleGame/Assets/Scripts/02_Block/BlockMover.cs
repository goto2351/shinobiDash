using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : Config
{
    public float BlockSpeedX { get; set; }

    void FixedUpdate()
    {
        // ゲームオーバー時処理を止める
        if (!is_game_over)
        {
            this.gameObject.transform.Translate(-BlockSpeedX * block_speed_relative, 0, 0);

            //画面外に出た時の処理を既定
            if (this.gameObject.transform.position.x < DestroyPositionX)
            {
                FlameOut(this.gameObject);
            }
        }
    }

    //オブジェクトが画面外に出た時の処理を規定
    void FlameOut(GameObject gameObject)
    {
        Destroy(gameObject);
    }

}