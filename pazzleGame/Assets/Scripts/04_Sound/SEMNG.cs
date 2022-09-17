using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEMNG : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;
    // プレイヤーのジャンプ音
    [SerializeField] private AudioClip seJump;
    // プレイヤーの被ダメージ音
    [SerializeField] private AudioClip seDamaged;
    // プレイヤーの攻撃音
    [SerializeField] private AudioClip seAttack;
    // 攻撃がヒットしたときのSE
    [SerializeField] private AudioClip seAttackHit;
    // スピードアップののSE
    [SerializeField] private AudioClip seSpeedUp;
    // 回復した時のSE
    [SerializeField] private AudioClip seHeal;

    // ジャンプ音を再生する
    public void SEJump()
    {
        audioSource.PlayOneShot(seJump);
    }

    // 被ダメージ音を再生する
    public void SEDamaged()
    {
        audioSource.PlayOneShot(seDamaged);
    }

    //攻撃音を再生する
    public void SEAttack()
    {
        audioSource.PlayOneShot(seAttack);
    }

    // 攻撃がヒットしたときのSEを再生する
    public void SEAttackHit()
    {
        audioSource.PlayOneShot(seAttackHit);
    }

    // 回復したときのSEを再生する
    public void SESpeedUp()
    {
        audioSource.PlayOneShot(seSpeedUp);
    }

    // 回復したときのSEを再生する
    public void SEHeal()
    {
        audioSource.PlayOneShot(seHeal);
    }
}
