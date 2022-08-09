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
        // ゲームオーバー時処理を止める
        if (!is_game_over)
        {
            // 方向キーで横移動
            // 入力の横軸の値を取得する
            float move_horizontal = Input.GetAxis("Horizontal");
            // ステージの範囲内で移動する
            /*
            Vector3 pos = gameObject.transform.position;
            Vector3 pos_new = new Vector3(Mathf.Clamp(pos.x + move_horizontal * Time.deltaTime * moveSpeed, -11f, 11f), pos.y, 0);
            gameObject.transform.position = pos_new;
            */
            rb.velocity = new Vector2(move_horizontal * moveSpeed, rb.velocity.y);

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
            // TODO: 攻撃に当たり判定を付ける
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
