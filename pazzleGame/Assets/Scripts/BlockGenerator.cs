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
    public int GeneratePace = 3;

    private int generateCount;
    
    // Start is called before the first frame update
    void Start()
    {
        // �����u���b�N�𐶐�
        for(int i = 0 ; i < 15;i++)
        {
            BlockGenerate(i - 5, false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        generateCount++;
        // ����I�Ƀu���b�N�𐶐�����
        if (generateCount >= GeneratePace)
        {
            BlockGenerate();
            generateCount = 0;
        }
    }

    // �u���b�N��������
    void BlockGenerate(float posX = DefaultPosX,bool randFlag = true)
    {
        float posY = DefaultPosY;

        // �u���b�N������Y�����u��������
        if (randFlag)
        {
            posY = Random.Range(DefaultMinPosY, DefaultMaxPosY);
        }
        // �����ʒu���w��
        Vector3 pos = new Vector3(posX, posY);
        // ��������
        Instantiate(BlockA, pos, Quaternion.identity);
    }

}