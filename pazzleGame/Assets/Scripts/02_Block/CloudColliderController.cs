using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class CloudColliderController : MonoBehaviour
{
    // 雲の画像の縦の長さ
    private const float CLOUD_SPRITE_HEIGHT = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // オブジェクトが上から衝突してきたとき当たり判定を付ける
        if (collision.gameObject.transform.position.y > gameObject.transform.position.y - 0.25f) 
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // オブジェクトが離れる時トリガーに戻す
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }
}
