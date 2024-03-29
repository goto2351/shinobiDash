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
            ret = "近所の公園";
        }
        // 品川6.8km
        else if (current_distance < 17.0f)
        {
            ret = "品川駅(約7km)";
        }
        // ディズニーランド17km
        else if (current_distance < 30.0f)
        {
            ret = "ディズニーランド(約17km)";
        }
        //横浜30km
        else if (current_distance < 60.0f)
        {
            ret = "横浜(約30km)";
        }
        //つくば60km
        else if (current_distance < 105.0f)
        {
            ret = "つくば(約60km)";
        }
        //熱海105km
        else if (current_distance < 180.0f)
        {
            ret = "熱海(約105km)";
        }
        //静岡180km
        else if (current_distance < 260.0f)
        {
            ret = "静岡(約180km)";
        }
        //浜松260km
        else if (current_distance < 360.0f)
        {
            ret = "浜松(約260km)";
        }
        //名古屋360km
        else if (current_distance < 500.0f)
        {
            ret = "名古屋(約360km)";
        }
        //京都500km
        else
        {
            ret = "京都到着！(約500km) 東海道走破おめでとう！";
        }

        if (current_distance < 500.0f)
        {
            return "あなたは「" + ret + "」に到達しました！";
        }
        else
        {
            return ret;
        }


    }

}
