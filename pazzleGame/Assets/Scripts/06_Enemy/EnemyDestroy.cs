using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : Config
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーとぶつかった場合、オブジェクトを消滅させる
        if (collision.gameObject.tag == TAG_NAME_PLAYER)
        {
            Destroy(this.gameObject);
        }
    }
}
