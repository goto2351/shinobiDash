using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : Config
{
    public GameObject backGround;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0.0f, 1.0f, 0.0f);
        // ê∂ê¨èàóù
        Instantiate(backGround, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
