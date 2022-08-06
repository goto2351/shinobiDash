using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : Config
{
    public float BlockSpeedX { get; set; }

    void FixedUpdate()
    {
        this.gameObject.transform.Translate(-BlockSpeedX, 0, 0);

        //��ʊO�ɏo�����̏���������
        if (this.gameObject.transform.position.x < DestroyPositionX)
        {
            FlameOut(this.gameObject);
        }

    }

    //�I�u�W�F�N�g����ʊO�ɏo�����̏������K��
    void FlameOut(GameObject gameObject)
    {
        Destroy(gameObject);
    }

}