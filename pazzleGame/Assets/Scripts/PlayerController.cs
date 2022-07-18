using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

///<summary>
/// プレイヤーキャラクターの操作を扱うコンポーネント
///</summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce; // ジャンプ力

    // 最大ジャンプ回数
    private const int MAX_JUMP_NUM = 2;

    // ジャンプに対応するキー
    private const KeyCode KEY_JUMP = KeyCode.Space;
    // 攻撃に対応するキー
    private const KeyCode KEY_ATTACK = KeyCode.A;

    //private bool isJumping = false;
    public int numJump; // 現在ジャンプしている回数(0: 着地中)

    // Start is called before the first frame update
    void Start()
    {
        // ジャンプ状態の初期化
        numJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーでジャンプ
        // 最大ジャンプ回数に達していない時ジャンプを実行する
        if (Input.GetKeyDown(KeyCode.Space) && numJump < MAX_JUMP_NUM)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            numJump++;
        }
        // ジャンプ状態をAnimatorと同期する(ジャンプ回数>=1のときジャンプ中)
        animator.SetBool("isJumping", numJump >= 1);

        // Aキー(仮)で攻撃
        // TODO: 攻撃に当たり判定を付ける
        if (Input.GetKeyDown(KEY_ATTACK))
        {
            animator.SetTrigger("isAttacking");
        }
    }
}
