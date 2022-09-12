using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEMNG : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;
    // �v���C���[�̃W�����v��
    [SerializeField] private AudioClip seJump;
    // �v���C���[�̔�_���[�W��
    [SerializeField] private AudioClip seDamaged;
    // �v���C���[�̍U����
    [SerializeField] private AudioClip seAttack;
    // �U�����q�b�g�����Ƃ���SE
    [SerializeField] private AudioClip seAttackHit;

    // �W�����v�����Đ�����
    public void SEJump()
    {
        audioSource.PlayOneShot(seJump);
    }

    // ��_���[�W�����Đ�����
    public void SEDamaged()
    {
        audioSource.PlayOneShot(seDamaged);
    }

    //�U�������Đ�����
    public void SEAttack()
    {
        audioSource.PlayOneShot(seAttack);
    }

    // �U�����q�b�g�����Ƃ���SE���Đ�����
    public void SEAttackHit()
    {
        audioSource.PlayOneShot(seAttackHit);
    }
}
