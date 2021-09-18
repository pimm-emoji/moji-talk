using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementsManager : MonoBehaviour
{
    public List<Achievement> achievements;

    void Awake()
    {
        LoadAchievements();
        Debug.Log(achievements[0].id);
    }

    public void Refresh()
    {
        LoadAchievements();
    }

    public void LoadAchievements()
    {
        List<string> index = PresetController.LoadSingleDepth<string>(AssetLoader.LoadJsonToArray("Presets/achievements"));  //string 형 리스트 index
        foreach (string index_obj in index)
        {
            achievements.Add(AssetLoader.LoadJsonToObject($"Presets/achievements/{index_obj}").ToObject<Achievement>());
        }
    }
    /*
    public void CheckCondition()
    {
        for(int i = 0; i< achievements.length; i++){    
        if (achievements[i].id == "hawkeye_1")
        {
            if(GameManager.instance.bad + GameManager.instance.miss < 20){
                achievements[i].condition = true;}
            else{ achievement[i].condition = false;}
        }

        .....
            
        else if(achievements[i].id == "else"){
        if(achievement 


            ......
    }
    
}
    */

    [System.Serializable]
    public class Achievement
    {
        public bool condition;
        public string id;
        public string displayName;
        public string description;
        public string imgAssetPath;
        public Sprite imgAssetSprite;

        public Achievement(bool Condition)
        {
            condition = Condition;
        }

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
        { }
    }
}