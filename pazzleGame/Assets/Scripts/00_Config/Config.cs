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
    public const string TAG_NAME_PLAYER = "Player";

    // �V�[����
    public const string SCENE_NAME_FIELD = "Field";
    public const string SCENE_NAME_GAMEOVER = "GameOver";

    /*  
     *  _/_/_/_/_/_/_/_/_/_/_/_/
     *  
     *      ��static�ϐ���
     *      
     *  _/_/_/_/_/_/_/_/_/_/_/_/
     */

    // ���݂̑��s����
    public static float current_distance;
    // ���݂̃v���C���[�̗�(0�ȉ��ɂȂ��GAMEOVER) 
    public static int current_life;
    // �����̎��������t���O
    public static bool can_construct;
    // �Q�[���I�[�o�[�t���O
    public static bool is_game_over;

    // static�ϐ��̏�����
    public void Initialize()
    {
        current_distance = 0;
        current_life = 3;
        can_construct = true;
        is_game_over = false;
    }

    // TODO ��ŏ���
    public void log(string s)
    {
        Debug.Log(s);
    }

}
