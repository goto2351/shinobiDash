using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTouch : ConfigChara
{
    // 効果音再生用
    public SEMNG se;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == TAG_NAME_ENEMY)
        {
            if (!IsDamaged) 
            {
                IsDamaged = true;
                // SE再生
                se.SEDamaged();
                // PLのライフ減少
                current_life--;
                // 一定時間後に再度ダメージ判定を有効化
                Invoke(nameof(CancelMuteki),MutekiTime);
            }
        }  
    }

    void CancelMuteki()
    {
        IsDamaged = false;
    }
}
