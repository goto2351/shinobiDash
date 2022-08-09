using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ResultUIUpdate : Config
{
    public GameObject ResultObj;
    Text distanceText;


    // Start is called before the first frame update
    void Start()
    {
        distanceText = ResultObj.GetComponent<Text>();

    }


    private void FixedUpdate()
    {
        distanceText.text = "Result : " + (current_distance).ToString("f2") + "km";
    }

}
