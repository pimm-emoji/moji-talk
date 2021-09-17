using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class AchievementsManager : MonoBehaviour
{
    List<Achievement> achievements;
    void Awake()
    {
        LoadAchievements();
    }

    public void Refresh()
    {
        LoadAchievements();
    }

    public void LoadAchievements()
    {
        List<string> index = PresetController.LoadSingleDepth<string>(AssetLoader.LoadJsonToArray("Presets/achievemtns"));
        foreach (string index_obj in index)
        {
            achievements.Add(AssetLoader.LoadJsonToObject($"Presets/achievements/{index_obj}").ToObject<Achievement>());
        }
    }
}*/

[System.Serializable]
public class Achievement
{
    public string id;
    public string displayName;
    public string description;
    public string imgAssetPath;
    public Sprite imgAssetSprite;
    public Achievement(string ID, string DisplayName, string Description)
    {
        id = ID;
        displayName = DisplayName;
        description = Description;
    }
    public Achievement(string ID, string DisplayName, string Description, string ImgAssetPath)
    {
        id = ID;
        displayName = DisplayName;
        description = Description;
        imgAssetPath = ImgAssetPath;
        imgAssetSprite = Resources.Load<Sprite>(imgAssetPath);
    }

    public void Load(string ImgAssetPath)
    {
        imgAssetPath = ImgAssetPath;
        imgAssetSprite = Resources.Load<Sprite>(imgAssetPath);
    }

    public static void Grant(string id)
    {
        
    }
    public static void Revoke(string id)
    {}
}
