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
    public GameObject LevelUpObj;
    public GameObject particleObj;
    Text distanceText;
    Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        distanceText = DistanceObj.GetComponent<Text>();
        lifeText =LifeObj.GetComponent<Text>();
    }

    private void Update()
    {
        // ポーズする
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }


    private void FixedUpdate()
    {
        distanceText.text = "走行距離 " + (current_distance).ToString("f2") + "km！";
        lifeText.text = "残り体力：" + current_life;
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

}
