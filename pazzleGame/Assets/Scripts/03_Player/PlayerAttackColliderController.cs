using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerAttackColliderController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 敵に攻撃が当たった時の消滅処理
    public  void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Enemy")
        {
            // SEを鳴らす
            GameObject.Find("SE_MNG").GetComponent<SEMNG>().SEAttackHit();
            // 敵オブジェクトを消滅させる
            Destroy(collision.gameObject);
        }
    }
}
