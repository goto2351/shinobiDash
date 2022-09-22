using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GUIUpdate : Config
{
    // 効果音再生用
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
        // 体力値を取得
        ChangeLife();
    }

    private void Update()
    {
        // ポーズする
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
        distanceText.text = "走行距離 " + (current_distance).ToString("f2") + "km！";
        lifeText.text = "残り体力：" + current_life;

        //体力の変化を検知
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

    //体力GUIを更新
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
