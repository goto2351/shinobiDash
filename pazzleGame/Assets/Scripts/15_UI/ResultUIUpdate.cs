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
        reachedPlaceText.text = "あなたは「東京 ⇒ " + WhereReached() + "」に到達しました！";

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
        else if (current_distance < 15.0f)
        {
            ret = "品川";
        }
        else if (current_distance < 30.0f)
        {
            ret = "ディズニーランド";
        }
        else if (current_distance < 50.0f)
        {
            ret = "横浜";
        }


            return ret;
    }

}
