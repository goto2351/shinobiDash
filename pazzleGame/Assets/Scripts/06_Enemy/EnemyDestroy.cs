using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : Config
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �v���C���[�ƂԂ������ꍇ�A�I�u�W�F�N�g�����ł�����
        if (collision.gameObject.tag == TAG_NAME_PLAYER)
        {
            Destroy(this.gameObject);
        }
    }
}
