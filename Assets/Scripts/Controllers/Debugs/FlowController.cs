using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class FlowController : MonoBehaviour
{
    void Start(){}
    void Update(){}

    [ContextMenu("Load Level Data")]
    void LoadLevel()
    {
        JObject jobj = PresetController.LoadJsonToObject(PathVariables.LevelIndexPath);
        print(jobj);
        Dictionary<string, Level> level = PresetController.LoadSingleDepth<Level>(jobj);
        foreach (var key in level.Keys)
        {
            print(key.ToString());
            print(level[key].type);
        }
    }
}
