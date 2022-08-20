using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class CloudColliderController : MonoBehaviour
{
    // �_�̉摜�̏c�̒���
    private const float CLOUD_SPRITE_HEIGHT = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �I�u�W�F�N�g���ォ��Փ˂��Ă����Ƃ������蔻���t����
        if (collision.gameObject.transform.position.y > gameObject.transform.position.y - 0.25f) 
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // �I�u�W�F�N�g������鎞�g���K�[�ɖ߂�
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
    }
}
