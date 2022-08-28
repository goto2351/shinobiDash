using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ResultUIUpdate : Config
{
    public GameObject ResultObj;
    public GameObject ReachedPlaceObj;
    Text distanceText;
    Text reachedPlaceText;


    // Start is called before the first frame update
    void Start()
    {
        distanceText = ResultObj.GetComponent<Text>();
        reachedPlaceText = ReachedPlaceObj.GetComponent<Text>();
        reachedPlaceText.text = "���Ȃ��́u���� �� " + WhereReached() + "�v�ɓ��B���܂����I";

    }


    private void FixedUpdate()
    {
        distanceText.text = "Result : " + (current_distance).ToString("f2") + "km";
    }

    private string WhereReached()
    {
        string ret = "";

        if(current_distance < 7.0f)
        {
            ret = "�ߏ��̌���";
        }
        else if (current_distance < 15.0f)
        {
            ret = "�i��";
        }
        else if (current_distance < 30.0f)
        {
            ret = "�f�B�Y�j�[�����h";
        }
        else if (current_distance < 50.0f)
        {
            ret = "���l";
        }


            return ret;
    }

}
