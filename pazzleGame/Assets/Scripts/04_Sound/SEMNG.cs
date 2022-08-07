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

}
