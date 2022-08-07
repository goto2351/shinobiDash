using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �Q�[���S�̂��Ǘ����鏈���������X�N���v�g
public class GameDirector : Config
{
    // �Q�[���I�[�o�[�\���܂ł̎���
    public float displayDelay = 1.5f;
    // �Q�[���I�[�o�[�J�ڂ܂ł̎���
    public float gameOverDelay = 2.5f;
    // �v���C���[�̃R���C�_�[
    public BoxCollider2D PLcollider;
    public BoxCollider2D PLcollider2;
    public GUIUpdate guiUpdate;
    bool gameOverFlg;

    // Start is called before the first frame update
    void Awake()
    {
        Initialize();
        ChangeColiderEnabled(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_life <= 0)
        {
            is_game_over = true;
        }

        if (is_game_over)
        {
            if (!gameOverFlg)
            {
                gameOverFlg = true;
                // �v���C���[�̓����蔻����Ȃ���
                ChangeColiderEnabled(false); 
                // �w�莞�Ԍ�Q�[���I�[�o�[��\������
                guiUpdate.GameOver(displayDelay);
                // �w�莞�Ԍ�Q�[���I�[�o�[�̃V�[���J��
                Invoke(nameof(ChangeSceneGameOver), displayDelay + gameOverDelay);
            }
        }

    }
    // �R���C�_�[�̗L�������ύX����
    void ChangeColiderEnabled(bool able)
    {       
        PLcollider.enabled = able;
        PLcollider2.enabled = able;
    }

    //�V�[����ς���
    void ChangeSceneGameOver()
    {
        SceneManager.LoadScene(SCENE_NAME_GAMEOVER);
    }
}
