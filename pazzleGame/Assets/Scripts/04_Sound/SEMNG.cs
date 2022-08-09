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

}
