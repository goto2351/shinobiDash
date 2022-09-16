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
            ret = "‹ßŠ‚ÌŒö‰€";
        }
        // •iì6.8km
        else if (current_distance < 17.0f)
        {
            ret = "•iì‰w";
        }
        // ƒfƒBƒYƒj[ƒ‰ƒ“ƒh17km
        else if (current_distance < 30.0f)
        {
            ret = "ƒfƒBƒYƒj[ƒ‰ƒ“ƒh";
        }
        //‰¡•l30km
        else if (current_distance < 60.0f)
        {
            ret = "‰¡•l";
        }
        //‚Â‚­‚Î60km
        else if (current_distance < 105.0f)
        {
            ret = "‚Â‚­‚Î";
        }
        //”MŠC105km
        else if (current_distance < 180.0f)
        {
            ret = "”MŠC";
        }
        //Ã‰ª180km
        else if (current_distance < 260.0f)
        {
            ret = "Ã‰ª";
        }
        //•l¼260km
        else if (current_distance < 360.0f)
        {
            ret = "•l¼";
        }
        //–¼ŒÃ‰®360km
        else if (current_distance < 500.0f)
        {
            ret = "–¼ŒÃ‰®";
        }
        //‹ž“s500km
        else
        {
            ret = "‹ž“s“ž’…I“ŒŠC“¹‘–”j‚¨‚ß‚Å‚Æ‚¤I";
        }

        if (current_distance < 500.0f)
        {
            return "‚ ‚È‚½‚Íu" + ret + "v‚É“ž’B‚µ‚Ü‚µ‚½I";
        }
        else
        {
            return ret;
        }


    }

}
