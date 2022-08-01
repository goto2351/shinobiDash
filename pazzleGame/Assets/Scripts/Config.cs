using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // �u���b�N�����ʒu(X���W)
    public const float DefaultPosX = 15.0f;
    // �u���b�N�����ʒu(Y���W)(��{�I�ɏ����z�u�Ɏg��)
    public const float DefaultPosY = -4.0f;

    // �u���b�N�̍폜�����ʒu���w��
    public const float DestroyPositionX = -15.0f;

    // �^�O
    public const string TAG_NAME_ENEMY = "Enemy";
    public const string TAG_NAME_GROUND = "Ground";

    public static float Currentdistance = 0;
    public static int CurrentLife = 3;
    public static bool CanConstruct = true; 

}
