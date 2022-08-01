using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : Config
{
    public GameObject Base;
    public GameObject House;
    public GameObject SmallBuild;

    public int Level1;
    public int Level2;

    private bool level1Used;
    private bool level2Used;

    BlockGenerator baseGenerator;
    BlockGenerator houseGenerator;
    BlockGenerator smallBuildGenerator;

    // Start is called before the first frame update
    void Start()
    {
        baseGenerator = Base.GetComponent<BlockGenerator>();
        houseGenerator = House.GetComponent<BlockGenerator>();
        smallBuildGenerator = SmallBuild.GetComponent<BlockGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!level1Used)
        {
            if (Currentdistance >= Level1)
            {
                baseGenerator.paceContorller(2);
                level1Used = true;
            }
        }
        if (!level2Used)
        {
            if (Currentdistance >= Level2)
            {
                baseGenerator.paceContorller(10, 3, 5, 5, 8);
                smallBuildGenerator.paceContorller(100, 10, 20, 1, 2);
                level2Used = true;
            }
        }


    }
}
