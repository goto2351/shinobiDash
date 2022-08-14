using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : Config
{
    public GameObject BlockA;

    // �u���b�N�����ʒu����(Y���W)
    public float DefaultMinPosY = 0.0f;
    // �u���b�N�����ʒu���(Y���W)
    public float DefaultMaxPosY = 0.0f;
    // �u���b�N�̐����Ԋu(�傫���قǒx��)
    public float GeneratePace = 1;
    // �u���b�N�̐��������_��(�ő�ŏ�)
    public bool IsGenerateRandom = false;
    public int GenerateRateMin = 1;
    public int GenerateRateMax = 1;
    //�������̃u���b�N��
    public int GenerateBlocksMin = 1;
    public int GenerateBlocksMax = 1;

    // �u���b�N�̗���鑬�x���w��(�������ŕ����͔��]���邽�߁A�������𐳂Ƃ���)
    public float BlockSpeedX = 0.1f;
    // �J�n���ɂ��̃u���b�N����邩
    public bool IsStartGenerate = false;
    //���̃u���b�N����̑��ꂩ
    public bool IsBase = false;
    //���̃u���b�N���󒆂ɔz�u�������̂�
    public bool IsAir = false;

    private float width;
    private float height;
    // �����y�[�X���Ǘ���������J�E���^�[
    private float paceCount = 0;
    private float currentPace; 
    //�@�����u���b�N�����Ǘ���������J�E���^�[
    private int chainCount = 0;
    private int chainMax = 1;

    // �����y�[�X�𓮓I�ɕύX����
    public void paceContorller(float pace) 
    {
        GeneratePace = pace;
        IsGenerateRandom = false;
    }
    public void paceContorller(float pace, int rateMin, int rateMax, int blocksMin, int blocksMax)
    {
        GeneratePace = pace;
        IsGenerateRandom = true;
        GenerateRateMin = rateMin;
        GenerateRateMax = rateMax;
        GenerateBlocksMin = blocksMin;
        GenerateBlocksMax = blocksMax;
        // �u���b�N�A�������`
        ResetChain();
    }


    // Start is called before the first frame update
    void Start()
    {
        //�������擾
        width = BlockA.GetComponent<SpriteRenderer>().bounds.size.x;
        //�������擾
        height = BlockA.GetComponent<SpriteRenderer>().bounds.size.y;

        if (IsStartGenerate)
        {
            float generatePos = DestroyPositionX;
            // �����u���b�N�𐶐�
            while (generatePos <= DefaultPosX)
            {
                BlockGenerate(generatePos, false);
                // �u���b�N�̕������炷
                generatePos += width;
            }
            // �����␳
            paceCount = BlockSpeedX;
        }
        // �u���b�N�A�������`
        ResetChain();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �Q�[���I�[�o�[���������~�߂�
        if (!is_game_over)
            {
            // ����I�Ƀu���b�N�𐶐�����
            if (paceCount >= width)
            {
                if (IsBase || can_construct || IsAir)
                {
                    BlockGenerate();
                    can_construct = IsBase;

                    chainCount++;
                    // �A���z�u���I�����邩����
                    if (chainCount >= chainMax)
                    {
                        // �J�E���g�����Z�b�g
                        paceCount = 0;
                        // �u���b�N�A�������Ē�`
                        ResetChain();
                    }
                    else
                    {
                        // �J�E���g�����Z�b�g
                        paceCount = 0;
                        currentPace = 1;
                    }
                }
            }

        }
        else
        {
            // �x�[�X������Ă��Ȃ��Ƃ��㕨���z�u���Ȃ�
            if (IsBase)
            {
                can_construct = false;
            }
        }


        // �����J�E���g��i�߂�
        if (IsGenerateRandom &&  currentPace >= GenerateRateMin)
        {
            // ��`�����͈͓��Ő����y�[�X��ςݏグ�Ă����i����͖����ł�₱�����̂�+1���Ă���j
            paceCount += BlockSpeedX * Random.Range(GenerateRateMin, GenerateRateMax + 1) / currentPace;
        }
        else
        {
            paceCount += BlockSpeedX / currentPace;
        }
        
    }

    // �u���b�N��������
    void BlockGenerate(float posX = DefaultPosX, bool randFlag = true)
    {
        float posY = DefaultPosY;

        // �u���b�N������Y�����u��������
        if (randFlag)
        {
            posY = Random.Range(DefaultMinPosY, DefaultMaxPosY);
        }
        // �����ʒu���w��
        Vector3 pos = new Vector3(posX + height / 2, posY - width / 2);
        // ��������
        GameObject obj = Instantiate(BlockA, pos, Quaternion.identity);
        BlockMover mover = obj.GetComponent<BlockMover>();
        mover.BlockSpeedX= BlockSpeedX;
    }

    public void ResetChain()
    {
        chainCount = 0;
        // ��`�����͈͓��ŉ��u���b�N��A������邩�i����͖����ł�₱�����̂�+1���Ă���j
        chainMax = Random.Range(GenerateBlocksMin, GenerateBlocksMax + 1);
        //�����y�[�X�����Z�b�g
        currentPace = GeneratePace;
    }

}