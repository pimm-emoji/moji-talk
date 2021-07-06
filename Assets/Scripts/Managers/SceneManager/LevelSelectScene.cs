using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelSelectScene : MonoBehaviour
{
    public Dictionary<string, LevelData> levels;
    public GameObject WrapperControllerPrefab;
    void Start()
    {
        // string prefabPath = Path.Combine(Configs.PrefabPath, "LevelSelectScene", "SidebarContentWrapper", "SidebarContentWrapper.prefab");
        // WrapperControllerPrefab = Resources.Load(prefabPath, typeof(GameObject)) as GameObject;
        levels = GameManager.instance.GetLevelsPreset();
        foreach (KeyValuePair<string, LevelData> items in levels)
        {
            GameObject newObject = Instantiate(WrapperControllerPrefab) as GameObject;
            newObject.transform.SetParent(GameObject.Find("Content").transform);
            newObject.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 200f);
            newObject.GetComponent<WrapperController>().Init(items.Value.name, items.Value.desc, Path.Combine(Configs.ResourcePath, items.Value.img));
        }
    }
}
