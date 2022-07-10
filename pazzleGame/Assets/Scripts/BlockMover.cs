using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    // ブロックの削除される位置を指定
    public const float DestroyPositionX = -10.0f;
    // ブロックの流れる速度を指定(処理内で符号は反転するため、左方向を正とする)
    public float BlockSpeedX = 1.0f;

    private Rigidbody2D rb;
    private Vector3 speed;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
        speed = new Vector3(-BlockSpeedX, 0.0f, 0.0f);    // 速度を設定
    }
    void FixedUpdate()
    {
        //TODO 速度確認用
        //Debug.Log( this.gameObject.name + rb.velocity.x);
        rb.velocity = speed;    // 速度を与える

        //画面外に出た時の処理を既定
        if (this.gameObject.transform.position.x < DestroyPositionX)
        {
            FlameOut(this.gameObject);
        }

    }

    //オブジェクトが画面外に出た時の処理を規定
    void FlameOut(GameObject gameObject)
    {
        Destroy(gameObject);
    }

}