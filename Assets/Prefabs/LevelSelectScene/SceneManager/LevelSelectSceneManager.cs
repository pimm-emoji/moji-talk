using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectSceneManager : MonoBehaviour
{
    public GameObject levelBoxWrapperPrefab;
    public GameObject levelBoxWrapperInstantiateTarget;
    void Start()
    {
        foreach (string levelID in IngameDataManager.instance.levelIndexList)
        {
            GameObject newObject = Instantiate(levelBoxWrapperPrefab) as GameObject;
            Level eachLevelData = JsonIO.LoadJsonAssetToObject<Level>($"Presets/levels/{levelID}/configs");
            newObject.GetComponent<LevelBoxWrapperController>().Init(eachLevelData.name, eachLevelData.desc, eachLevelData.type);
            newObject.transform.position = new Vector2(0, 0);
            newObject.transform.SetParent(levelBoxWrapperInstantiateTarget.transform);
        }
    }

    void Update()
    {
        
    }
}
