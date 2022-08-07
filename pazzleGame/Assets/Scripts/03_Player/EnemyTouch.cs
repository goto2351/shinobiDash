using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTouch : ConfigChara
{
    // ���ʉ��Đ��p
    public SEMNG se;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == TAG_NAME_ENEMY)
        {
            if (!IsDamaged) 
            {
                IsDamaged = true;
                // SE�Đ�
                se.SEDamaged();
                // PL�̃��C�t����
                current_life--;
                // ��莞�Ԍ�ɍēx�_���[�W�����L����
                Invoke(nameof(CancelMuteki),MutekiTime);
            }
        }  
    }

    void CancelMuteki()
    {
        IsDamaged = false;
    }
}
