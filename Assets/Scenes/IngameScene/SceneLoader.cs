using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        LoadScene("Emote", LoadSceneMode.Additive);
        LoadScene("Message", LoadSceneMode.Additive);
    }

    void LoadScene(string sceneName, LoadSceneMode mode)
    {

        SceneManager.LoadScene(sceneName, mode);
    }
    
}