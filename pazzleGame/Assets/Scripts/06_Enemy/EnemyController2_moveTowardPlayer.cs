using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̓���(���@�_��)�̎���
/// </summary>
public class EnemyController2_moveTowardPlayer : MonoBehaviour
{
    // �v���C���[�̃I�u�W�F�N�g
    [SerializeField] private GameObject player;
    // �ǂ������鎞��(�b)
    [SerializeField] private float duration;
    // �ǂ������鑬��
    [SerializeField] private float moveSpeed;
    // ���Ԍo�߂̃J�E���g�p
    private float timeCount = 0;
    // �����Ԃ̃t���O
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[���߂Â��Ă����瓮��J�n�t���O�𗧂Ăē������������߂遨duration�̊Ԃ�����ɐi��
    }
}
