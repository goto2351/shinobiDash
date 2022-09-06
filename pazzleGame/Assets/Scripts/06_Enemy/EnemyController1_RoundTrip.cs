using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̓���(�������̉����j�̎���
/// </summary>
public class EnemyController1_RoundTrip : MonoBehaviour
{
    // ��������
    [SerializeField] private float moveSpeed;
    // ��������(�����)
    private Vector3 direction = new Vector3(0, 1f, 0);
    // �Е����ɓ�������
    [SerializeField] private float duration = 0.75f;
    // ���Ԍo�߂̃J�E���g�p
    private float timeCount = 0;
    // ���H�ƕ��H�̂ǂ��炩(���H��true)
    private bool moveMode = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ��莞�Ԃ��Ƃɉ������J��Ԃ�
        Vector3 pos = gameObject.transform.position;
        pos = moveMode ? pos + direction * Time.deltaTime * moveSpeed
                                    :pos - direction * Time.deltaTime * moveSpeed;
        gameObject.transform.position = pos;

        // �Г��̎��Ԃ��o�߂����瓮��������؂�ւ���
        timeCount += Time.deltaTime;
        if (timeCount >= duration)
        {
            moveMode = !moveMode;
            timeCount = 0;
        }
    }
}
