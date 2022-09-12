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
        reachedPlaceText.text = WhereReached();

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
        // �i��6.8km
        else if (current_distance < 17.0f)
        {
            ret = "�i��w";
        }
        // �f�B�Y�j�[�����h17km
        else if (current_distance < 30.0f)
        {
            ret = "�f�B�Y�j�[�����h";
        }
        //���l30km
        else if (current_distance < 60.0f)
        {
            ret = "���l";
        }
        //����60km
        else if (current_distance < 105.0f)
        {
            ret = "����";
        }
        //�M�C105km
        else if (current_distance < 180.0f)
        {
            ret = "�M�C";
        }
        //�É�180km
        else if (current_distance < 260.0f)
        {
            ret = "�É�";
        }
        //�l��260km
        else if (current_distance < 360.0f)
        {
            ret = "�l��";
        }
        //���É�360km
        else if (current_distance < 500.0f)
        {
            ret = "���É�";
        }
        //���s500km
        else
        {
            ret = "���s�����I���C�����j���߂łƂ��I";
        }

        if (current_distance < 500.0f)
        {
            return "���Ȃ��́u" + ret + "�v�ɓ��B���܂����I";
        }
        else
        {
            return ret;
        }


    }

}
