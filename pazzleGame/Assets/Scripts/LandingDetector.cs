using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
/// <summary>
/// キャラクターの着地を検出するコンポーネント
/// </summary>
public class LandingDetector : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 着地したときの処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たったのが地面の時
        // TODO: 今後"Grass"以外が出てきた場合はタグによる判定などに変更する
        if (collision.gameObject.name.Contains("Grass"))
        {
            // プレイヤーのジャンプ回数カウントを0にする
            player.GetComponent<PlayerController>().numJump = 0;
        }
    }
}
