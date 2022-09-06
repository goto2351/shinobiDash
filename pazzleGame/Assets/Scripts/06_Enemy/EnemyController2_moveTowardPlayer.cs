using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の動き(自機狙い)の実装
/// </summary>
public class EnemyController2_moveTowardPlayer : MonoBehaviour
{
    // プレイヤーのオブジェクト
    private GameObject player;
    // 追いかける時間(秒)
    [SerializeField] private float duration;
    // 追いかける速さ
    [SerializeField] private float moveSpeed;
    // 追いかけ始める距離(x座標の差)
    [SerializeField] private float startDistance;
    // 時間経過のカウント用
    private float timeCount = 0;
    // 動作状態のフラグ
    private bool isMoving = false;
    // 移動方向のベクトル
    private Vector3 vec_towardPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが近づいてきたら動作開始フラグを立てて動く方向を決める→durationの間そちらに進む
        if (gameObject.transform.position.x - player.transform.position.x <= startDistance && timeCount == 0)
        {
            isMoving = true;
            vec_towardPlayer = new Vector3(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y, 0);
        }

        if (isMoving)
        {
            // プレイヤーの向きに動かす
            Vector3 pos = gameObject.transform.position;
            pos += vec_towardPlayer * Time.deltaTime * moveSpeed;
            gameObject.transform.position = pos;

            // タイマーを加算
            timeCount += Time.deltaTime;
        }

        if (timeCount >= duration)
        {
            // 一定時間経過したら動きを止める
            isMoving = false;
        }
    }
}
