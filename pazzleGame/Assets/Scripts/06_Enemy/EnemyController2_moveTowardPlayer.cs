using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の動き(自機狙い)の実装
/// </summary>
public class EnemyController2_moveTowardPlayer : MonoBehaviour
{
    // プレイヤーのオブジェクト
    [SerializeField] private GameObject player;
    // 追いかける時間(秒)
    [SerializeField] private float duration;
    // 追いかける速さ
    [SerializeField] private float moveSpeed;
    // 時間経過のカウント用
    private float timeCount = 0;
    // 動作状態のフラグ
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが近づいてきたら動作開始フラグを立てて動く方向を決める→durationの間そちらに進む
    }
}
