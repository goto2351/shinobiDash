using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTouch : Config
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == TAG_NAME_ENEMY)
        {
            CurrentLife--;
        }  
    }
}
