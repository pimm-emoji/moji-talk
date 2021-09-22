using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{
    public ResultSceneGameObjects objects;
    public Ending ending;
    void Start()
    {
        // Debugging
        if (string.IsNullOrEmpty(GameManager.instance.nowLevelID))
        {
            GameManager.instance.nowLevelID = ResultSceneConfig.defaultDebuggingLevelID;
            GameManager.instance.endingID = ResultSceneConfig.defaultDebuggingEndingID;
            IngameDataManager.instance.LoadLevelEntire(GameManager.instance.nowLevelID);
        }
        // Load Ending Data
        Ending ending = IngameDataManager.instance.level.endings.Find(x => x.id == GameManager.instance.endingID);
        // Apply to Display
        objects.stageTitleObject.GetComponent<Text>().text = IngameDataManager.instance.level.name;
        objects.endingTitleObject.GetComponent<Text>().text = ending.name;
        objects.endingDescrpitionObject.GetComponent<Text>().text = $"엔딩 [{ending.id.ToUpper()}] 완료";
    }
}

[System.Serializable]
public class ResultSceneGameObjects
{
    public GameObject titleObject;
    public GameObject titleTextObject;
    public GameObject stageTitleObject;
    public GameObject endingWrapperObject;
    public GameObject endingTitleObject;
    public GameObject endingDescrpitionObject;
}