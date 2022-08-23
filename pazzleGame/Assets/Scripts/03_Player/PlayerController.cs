using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

///<summary>
/// プレイヤーキャラクターの操作を扱うコンポーネント
///</summary>
public class PlayerController : ConfigChara
{
    // 効果音再生用
    public SEMNG se;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce; // ジャンプ力
    [SerializeField] private float moveSpeed; // 移動速度

    // 最大ジャンプ回数
    private const int MAX_JUMP_NUM = 2;

    // ジャンプに対応するキー
    private const KeyCode KEY_JUMP = KeyCode.Space;
    // 攻撃に対応するキー
    private const KeyCode KEY_ATTACK = KeyCode.F;

    // 前後により移動速度に掛ける係数
    private const float VELOCITY_COEFF_FORWARD = 0.5f;
    private const float VELOCITY_COEFF_BACKWARD = 1.2f;

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
        // ゲームオーバー時処理を止める
        if (!is_game_over)
        {
            // 方向キーで横移動
            //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            //{
                // 入力の横軸の値を取得する
                float move_horizontal = Input.GetAxis("Horizontal");
                // x方向に設定する速度を前後により変える
                float velocity_x = move_horizontal * moveSpeed;
                velocity_x = move_horizontal >= 0 ? velocity_x * VELOCITY_COEFF_FORWARD : velocity_x * VELOCITY_COEFF_BACKWARD;
                rb.velocity = new Vector2(velocity_x, rb.velocity.y);
            //}

            // スペースキーでジャンプ
            // 最大ジャンプ回数に達していない時ジャンプを実行する
            if (Input.GetKeyDown(KeyCode.Space) && numJump < MAX_JUMP_NUM)
            {
                se.SEJump();
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                numJump++;
            }
            // ジャンプ状態をAnimatorと同期する(ジャンプ回数>=1のときジャンプ中)
            animator.SetBool("isJumping", numJump >= 1);

            // Aキー(仮)で攻撃
            if (Input.GetKeyDown(KEY_ATTACK))
            {
                animator.SetTrigger("isAttacking");
                gameObject.GetComponent<PlayerAtackController>().MakeAtackCollider();
            }
        }

        // 画面外に遷移時ゲームオーバーとする
        if (this.gameObject.transform.position.y < GameOverLineY)
        {
            is_game_over = true;
        }
    }
}
