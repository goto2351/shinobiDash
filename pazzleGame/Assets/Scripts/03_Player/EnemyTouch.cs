using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTouch : ConfigChara
{
    // 効果音再生用
    public SEMNG se;
    // 無敵時間のキャラクター点滅時にspriteRendererにセットするcolor
    // 通常時(白、不透明)
    private Color color_normal = new Color(1f, 1f, 1f, 1f);
    // 非表示状態(透明)
    private Color color_transparent = new Color(1f, 1f, 1f, 0f);
    // 点滅の状態管理用のタイマー
    private float FlickerTiemer = 0f;
    // 点滅の間隔
    private const float FLICKER_INTERVAL = 0.25f;
    // キャラクターの表示状態
    private bool isVisible = true;
    public SpriteRenderer sp;

    private void Update()
    {
        // 無敵状態のとき点滅させる
        if (IsDamaged)
        {
            if (FlickerTiemer >= FLICKER_INTERVAL)
            {
                // 表示状態の切り替え
                if (isVisible)
                {
                    MakeInvisible();
                } else
                {
                    MakeVisible();
                }
            }
            FlickerTiemer += Time.deltaTime;
        }
    }

    // 無敵時間の点滅用(表示させる)
    private void MakeVisible()
    {
        FlickerTiemer = 0f;
        sp.color = color_normal;
        isVisible = true;
    }

    // 無敵時間の点滅用(消す)
    private void MakeInvisible()
    {
        FlickerTiemer = 0f;
        sp.color = color_transparent;
        isVisible = false;
    }

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
                // 点滅を開始する(非表示にする)
                MakeInvisible();
                // 一定時間後に再度ダメージ判定を有効化
                Invoke(nameof(CancelMuteki),MutekiTime);
            }
        }
        else if(collision.gameObject.tag == TAG_NAME_HEART)
        {
            se.SEHeal();
            // PLのライフ回復
            current_life++;
        }
    }

    void CancelMuteki()
    {
        IsDamaged = false;
    }
}
