using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GUIUpdate : Config
{
    // ���ʉ��Đ��p
    public SEMNG se;

    public GameObject DistanceObj;
    public GameObject LifeObj;
    public GameObject GameOverObj;
    public GameObject PauseObj;
    public GameObject LevelUpObj;
    public GameObject particleObj;
    public GameObject HeartObj;
    Text distanceText;
    Text lifeText;

    int pastLife;

    // Start is called before the first frame update
    void Start()
    {
        distanceText = DistanceObj.GetComponent<Text>();
        lifeText =LifeObj.GetComponent<Text>();
        // �̗͒l���擾
        ChangeLife();
    }

    private void Update()
    {
        // �|�[�Y����
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!is_pause)
            {
                Time.timeScale = 0;
                is_pause = true;
                PauseObj.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                is_pause = false;
                PauseObj.SetActive(false);
            }
        }
    }


    private void FixedUpdate()
    {
        distanceText.text = "���s���� " + (current_distance).ToString("f2") + "km�I";
        lifeText.text = "�c��̗́F" + current_life;

        //�̗͂̕ω������m
        if (pastLife != current_life)
        {
            ChangeLife();
            
        }
    }
    public void GameOver(float displayDelay)
    {
        Invoke(nameof(ShowGameOverUI), displayDelay);
    }

    private void ShowGameOverUI()
    {
        GameOverObj.SetActive(true);

    }

    public void SpeedUp(float displayTime, bool particleFlag = false)
    {
        LevelUpObj.SetActive(true);
        particleObj.SetActive(true);
        Invoke(nameof(HideSpeedUp), displayTime);
        se.SESpeedUp();

        if (!particleFlag)
        {
            Invoke(nameof(HideParticle), displayTime);
        }

    }

    private void HideSpeedUp()
    {
        LevelUpObj.SetActive(false);
    }

    private void HideParticle()
    {
        particleObj.SetActive(false);
    }

    //�̗�GUI���X�V
    void ChangeLife()
    {
        for (int i = 0; i < HeartObj.transform.childCount; i++)
        {

            var obj = HeartObj.transform.GetChild(i);
            obj.gameObject.SetActive(i < current_life);
        }

        pastLife = current_life;
    }

}
