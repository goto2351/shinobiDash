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
}
