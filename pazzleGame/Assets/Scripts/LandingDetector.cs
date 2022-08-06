using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
/// <summary>
/// �L�����N�^�[�̒��n�����o����R���|�[�l���g
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

    // ���n�����Ƃ��̏���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������̂��n�ʂ̎�
        // TODO: ����"Grass"�ȊO���o�Ă����ꍇ�̓^�O�ɂ�锻��ȂǂɕύX����
        if (collision.gameObject.tag == "Ground")
        {
            // �v���C���[�̃W�����v�񐔃J�E���g��0�ɂ���
            player.GetComponent<PlayerController>().numJump = 0;
        }
    }
}
