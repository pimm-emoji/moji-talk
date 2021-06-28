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
        JObject jobj = PresetController.LoadJson(Configs.LevelIndexPath);
        print(jobj);
        Dictionary<string, LevelData> levelData = PresetController.LoadSingleDepth<LevelData>(jobj);
        foreach (var key in levelData.Keys)
        {
            print(key.ToString());
            print(levelData[key].type);
        }
    }
}
