using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigChara : Config
{
    // ���ꖢ�����ƃQ�[���I�[�o�[�ƂȂ�Y���̍��W
    public const float GameOverLineY = -6.0f;

    // �U���̍ē��͂܂ł̎���
    public const float AttackedTime = 0.5f;
    // �U���t���O
    public static bool IsAttacked = false;

    // ��_���[�W��̖��G����
    public const float MutekiTime = 1.0f;
    // ��_���[�W�t���O
    public static bool IsDamaged = false;
    // �񕜌�̍ĉ񕜂܂ł̎���
    public const float HealedTime = 0.1f;
    // ��񕜃t���O
    public static bool IsHealed = false;

}
