using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

///<summary>
/// �v���C���[�L�����N�^�[�̑���������R���|�[�l���g
///</summary>
public class PlayerController : ConfigChara
{
    // ���ʉ��Đ��p
    public SEMNG se;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce; // �W�����v��
    [SerializeField] private float moveSpeed; // �ړ����x

    // �ő�W�����v��
    private const int MAX_JUMP_NUM = 2;

    // �W�����v�ɑΉ�����L�[
    private const KeyCode KEY_JUMP = KeyCode.Space;
    // �U���ɑΉ�����L�[
    private const KeyCode KEY_ATTACK = KeyCode.A;

    //private bool isJumping = false;
    public int numJump; // ���݃W�����v���Ă����(0: ���n��)

    // Start is called before the first frame update
    void Start()
    {
        // �W�����v��Ԃ̏�����
        numJump = 0;

    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���I�[�o�[���������~�߂�
        if (!is_game_over)
        {
            // �����L�[�ŉ��ړ�
            // ���͂̉����̒l���擾����
            float move_horizontal = Input.GetAxis("Horizontal");
            // �X�e�[�W�͈͓̔��ňړ�����
            /*
            Vector3 pos = gameObject.transform.position;
            Vector3 pos_new = new Vector3(Mathf.Clamp(pos.x + move_horizontal * Time.deltaTime * moveSpeed, -11f, 11f), pos.y, 0);
            gameObject.transform.position = pos_new;
            */
            rb.velocity = new Vector2(move_horizontal * moveSpeed, rb.velocity.y);
            
            // �X�y�[�X�L�[�ŃW�����v
            // �ő�W�����v�񐔂ɒB���Ă��Ȃ����W�����v�����s����
            if (Input.GetKeyDown(KeyCode.Space) && numJump < MAX_JUMP_NUM)
            {
                se.SEJump();
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                numJump++;
            }
            // �W�����v��Ԃ�Animator�Ɠ�������(�W�����v��>=1�̂Ƃ��W�����v��)
            animator.SetBool("isJumping", numJump >= 1);

            // A�L�[(��)�ōU��
            // TODO: �U���ɓ����蔻���t����
            if (Input.GetKeyDown(KEY_ATTACK))
            {
                animator.SetTrigger("isAttacking");
                gameObject.GetComponent<PlayerAtackController>().MakeAtackCollider();
            }
        }

        // ��ʊO�ɑJ�ڎ��Q�[���I�[�o�[�Ƃ���
        if (this.gameObject.transform.position.y < GameOverLineY)
        {
            is_game_over = true;
        }
    }
}