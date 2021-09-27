using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string id;
    public bool condition;
    public string displayName;
    public string description;
    public string imgAssetPath;
    public Sprite imgAssetSprite;
    public Achievement(string ID, bool Condition, string DisplayName, string Description)
    {
        id = ID;
        condition = Condition;
        displayName = DisplayName;
        description = Description;
    }
    public Achievement(string ID, bool Condition, string DisplayName, string Description, string ImgAssetPath)
    {
        id = ID;
        condition = Condition;
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
