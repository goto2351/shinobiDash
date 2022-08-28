using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMover : Config
{
    // ブロックの流れる速度を指定(処理内で符号は反転するため、左方向を正とする)
    public float BlockSpeedX = 1.0f;

    private float width;
    private bool generateFlag;
    private float pastPlace;

    // Start is called before the first frame update
    void Start()
    {
        // プレハブ名の文字溢れを回避
        if(this.gameObject.name.Length > 50)
        {
            this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
        }
        //背景の横幅を取得
        width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        // 現在位置を取得
        pastPlace = this.gameObject.transform.position.x;
    }

    void FixedUpdate()
    {
        // ゲームオーバー時処理を止める
        if (!is_game_over)
        {
            // 背景を移動
            this.gameObject.transform.Translate(-BlockSpeedX * block_speed_relative, 0, 0);

            if (!generateFlag)
            {
                float currentPlace = this.gameObject.transform.position.x;
                // 移動距離を更新
                current_distance += (pastPlace - currentPlace) * block_speed_relative;
                // 現在位置を更新
                pastPlace = currentPlace;

                if (this.gameObject.transform.position.x <= 0)
                {
                    Vector3 pos = new Vector3(0.0f + this.gameObject.transform.position.x + width, 1.0f, 0.0f);
                    // 生成処理
                    Instantiate(this.gameObject, pos, Quaternion.identity);
                    // 生成は一度だけ
                    generateFlag = true;
                }
            }

            //画面外に出た時の処理を既定
            if (this.gameObject.transform.position.x < DestroyPositionX - width / 2)
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
