using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneBackButtonController : MonoBehaviour
{
    public void OnClickHandler()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }
}
