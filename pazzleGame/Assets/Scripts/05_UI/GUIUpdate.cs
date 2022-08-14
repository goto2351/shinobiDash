using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GUIUpdate : Config
{
    public GameObject DistanceObj;
    public GameObject LifeObj;
    public GameObject GameOverObj;
    Text distanceText;
    Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        distanceText = DistanceObj.GetComponent<Text>();
        lifeText =LifeObj.GetComponent<Text>();
    }


    private void FixedUpdate()
    {
        distanceText.text = "���s���� " + (current_distance).ToString("f2") + "km�I";
        lifeText.text = "�c��̗́F" + current_life;
    }
    public void GameOver(float displayDelay)
    {
        Invoke(nameof(ShowGameOverUI), displayDelay);
    }

    private void ShowGameOverUI()
    {
        GameOverObj.SetActive(true);

    }

}