using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelSelectScene : MonoBehaviour
{
    public Dictionary<string, Level> levels;
    public GameObject WrapperControllerPrefab;
    void Start()
    {
        levels = PresetController.LoadSingleDepth<Level>(
            PresetController.LoadJsonToObject(Configs.LevelIndexPath)
        );
        foreach (KeyValuePair<string, Level> items in levels)
        {
            GameObject newObject = Instantiate(WrapperControllerPrefab) as GameObject;
            newObject.transform.SetParent(GameObject.Find("Content").transform);
            newObject.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 200f);
            newObject.GetComponent<LevelSelectWrapperController>().Init(items.Value.name, items.Value.desc, items.Value.img);
        }
    }
}
