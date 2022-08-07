using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : Config
{
    public GameObject gameOverObj;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SCENE_NAME_FIELD);
    }
}
