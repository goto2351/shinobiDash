using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̓���(���@�_��)�̎���
/// </summary>
public class EnemyController2_moveTowardPlayer : MonoBehaviour
{
    // �v���C���[�̃I�u�W�F�N�g
    private GameObject player;
    // �ǂ������鎞��(�b)
    [SerializeField] private float duration;
    // �ǂ������鑬��
    [SerializeField] private float moveSpeed;
    // �ǂ������n�߂鋗��(x���W�̍�)
    [SerializeField] private float startDistance;
    // ���Ԍo�߂̃J�E���g�p
    private float timeCount = 0;
    // �����Ԃ̃t���O
    private bool isMoving = false;
    // �ړ������̃x�N�g��
    private Vector3 vec_towardPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[���߂Â��Ă����瓮��J�n�t���O�𗧂Ăē������������߂遨duration�̊Ԃ�����ɐi��
        if (gameObject.transform.position.x - player.transform.position.x <= startDistance && timeCount == 0)
        {
            isMoving = true;
            vec_towardPlayer = new Vector3(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y, 0);
        }

        if (isMoving)
        {
            // �v���C���[�̌����ɓ�����
            Vector3 pos = gameObject.transform.position;
            pos += vec_towardPlayer * Time.deltaTime * moveSpeed;
            gameObject.transform.position = pos;

            // �^�C�}�[�����Z
            timeCount += Time.deltaTime;
        }

        if (timeCount >= duration)
        {
            // ��莞�Ԍo�߂����瓮�����~�߂�
            isMoving = false;
        }
    }
}
