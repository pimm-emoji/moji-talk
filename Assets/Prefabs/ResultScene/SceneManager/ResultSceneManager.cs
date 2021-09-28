using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour
{
    public ResultSceneGameObjects objects;
    public Ending ending;


    public GameObject AchvPrefab;
 



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
        objects.titleTextObject.GetComponent<Text>().text = "스테이지 완료";
        objects.stageTitleObject.GetComponent<Text>().text = IngameDataManager.instance.level.name;
        objects.endingTitleObject.GetComponent<Text>().text = ending.name;
        objects.endingDescrpitionObject.GetComponent<Text>().text = $"엔딩 [{ending.id.ToUpper()}] 완료";
        objects.endingScore.GetComponent<Text>().text = string.Format("총 스코어 {0}\n Perfect : {1}\n Great: {2} \n Good : {3}\n Bad : {4}\n Miss : {5}\n", GameManager.instance.userTotalScore, GameManager.instance.counts.perfect, GameManager.instance.counts.great, GameManager.instance.counts.good,GameManager.instance.counts.bad,GameManager.instance.counts.miss); 


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
    public GameObject endingScore;
}