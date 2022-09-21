using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTouch : ConfigChara
{
    // ���ʉ��Đ��p
    public SEMNG se;
    // ���G���Ԃ̃L�����N�^�[�_�Ŏ���spriteRenderer�ɃZ�b�g����color
    // �ʏ펞(���A�s����)
    private Color color_normal = new Color(1f, 1f, 1f, 1f);
    // ��\�����(����)
    private Color color_transparent = new Color(1f, 1f, 1f, 0f);
    // �_�ł̏�ԊǗ��p�̃^�C�}�[
    private float FlickerTiemer = 0f;
    // �_�ł̊Ԋu
    private const float FLICKER_INTERVAL = 0.25f;
    // �L�����N�^�[�̕\�����
    private bool isVisible = true;
    public SpriteRenderer sp;

    private void Update()
    {
        // ���G��Ԃ̂Ƃ��_�ł�����
        if (IsDamaged)
        {
            if (FlickerTiemer >= FLICKER_INTERVAL)
            {
                // �\����Ԃ̐؂�ւ�
                if (isVisible)
                {
                    MakeInvisible();
                } else
                {
                    MakeVisible();
                }
            }
            FlickerTiemer += Time.deltaTime;
        }
    }

    // ���G���Ԃ̓_�ŗp(�\��������)
    private void MakeVisible()
    {
        FlickerTiemer = 0f;
        sp.color = color_normal;
        isVisible = true;
    }

    // ���G���Ԃ̓_�ŗp(����)
    private void MakeInvisible()
    {
        FlickerTiemer = 0f;
        sp.color = color_transparent;
        isVisible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TAG_NAME_ENEMY)
        {
            if (!IsDamaged)
            {
                IsDamaged = true;
                // SE�Đ�
                se.SEDamaged();
                // PL�̃��C�t����
                current_life--;
                // �_�ł��J�n����(��\���ɂ���)
                MakeInvisible();
                // ��莞�Ԍ�ɍēx�_���[�W�����L����
                Invoke(nameof(CancelMuteki), MutekiTime);
            }
        }
        else if (collision.gameObject.tag == TAG_NAME_HEART)
        {
            // �d���񕜂�h�����߂̃t���O�`�F�b�N
            if (!IsHealed)
            {
                // �̗͏����9�Ƃ���
                if (current_life < 9)
                {
                    IsHealed = true;
                    // SE�Đ�
                    se.SEHeal();
                    // PL�̃��C�t��
                    current_life++;
                    // ��莞�Ԍ�ɍēx�񕜔����L����
                    Invoke(nameof(CancelHealed), HealedTime);
                }

            }

        }
    }

    // �����蔻����ėL����
    void CancelMuteki()
    {
        IsDamaged = false;
    }

    // �񕜔�����ėL����
    void CancelHealed()
    {
        IsHealed = false;
    }
}
