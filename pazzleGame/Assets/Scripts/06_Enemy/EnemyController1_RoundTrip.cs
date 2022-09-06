using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の動き(一定方向の往復）の実装
/// </summary>
public class EnemyController1_RoundTrip : MonoBehaviour
{
    // 動く速さ
    [SerializeField] private float moveSpeed;
    // 動く方向(上方向)
    private Vector3 direction = new Vector3(0, 1f, 0);
    // 片方向に動く時間
    [SerializeField] private float duration = 0.75f;
    // 時間経過のカウント用
    private float timeCount = 0;
    // 往路と復路のどちらか(往路がtrue)
    private bool moveMode = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 一定時間ごとに往復を繰り返す
        Vector3 pos = gameObject.transform.position;
        pos = moveMode ? pos + direction * Time.deltaTime * moveSpeed
                                    :pos - direction * Time.deltaTime * moveSpeed;
        gameObject.transform.position = pos;

        // 片道の時間が経過したら動く方向を切り替える
        timeCount += Time.deltaTime;
        if (timeCount >= duration)
        {
            moveMode = !moveMode;
            timeCount = 0;
        }
    }
}
