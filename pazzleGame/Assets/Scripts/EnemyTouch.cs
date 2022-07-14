using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTouch : Config
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentLife--;
    }
}
