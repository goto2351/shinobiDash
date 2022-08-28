using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMover : Config
{
    // �u���b�N�̗���鑬�x���w��(�������ŕ����͔��]���邽�߁A�������𐳂Ƃ���)
    public float BlockSpeedX = 1.0f;

    private float width;
    private bool generateFlag;
    private float pastPlace;

    // Start is called before the first frame update
    void Start()
    {
        // �v���n�u���̕����������
        if(this.gameObject.name.Length > 50)
        {
            this.gameObject.name = this.gameObject.name.Replace("(Clone)", "");
        }
        //�w�i�̉������擾
        width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        // ���݈ʒu���擾
        pastPlace = this.gameObject.transform.position.x;
    }

    void FixedUpdate()
    {
        // �Q�[���I�[�o�[���������~�߂�
        if (!is_game_over)
        {
            // �w�i���ړ�
            this.gameObject.transform.Translate(-BlockSpeedX * block_speed_relative, 0, 0);

            if (!generateFlag)
            {
                float currentPlace = this.gameObject.transform.position.x;
                // �ړ��������X�V
                current_distance += (pastPlace - currentPlace) * block_speed_relative;
                // ���݈ʒu���X�V
                pastPlace = currentPlace;

                if (this.gameObject.transform.position.x <= 0)
                {
                    Vector3 pos = new Vector3(0.0f + this.gameObject.transform.position.x + width, 1.0f, 0.0f);
                    // ��������
                    Instantiate(this.gameObject, pos, Quaternion.identity);
                    // �����͈�x����
                    generateFlag = true;
                }
            }

            //��ʊO�ɏo�����̏���������
            if (this.gameObject.transform.position.x < DestroyPositionX - width / 2)
            {
                FlameOut(this.gameObject);
            }
        }
    }

    //�I�u�W�F�N�g����ʊO�ɏo�����̏������K��
    void FlameOut(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
