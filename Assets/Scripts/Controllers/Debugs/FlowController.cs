using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class FlowController : MonoBehaviour
{
    void Start(){}
    void Update(){}

    [ContextMenu("Load Level Data")]
    void LoadLevelData()
    {
        JObject jobj = JsonController.LoadJson(Configs.LevelIndexPath);
        print(jobj);
        Dictionary<string, LevelData> levelData = JsonController.LoadSingleDepth<LevelData>(jobj);
        foreach (var key in levelData.Keys)
        {
            print(key.ToString());
            print(levelData[key].type);
        }
    }
}
