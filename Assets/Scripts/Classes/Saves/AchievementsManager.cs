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
        List<string> index = JsonIO.LoadJsonAssetToObject<AchievementsIDIndex>("Presets/achievements").index;
        foreach (string index_obj in index)
        {
            achievements.Add(JsonIO.LoadJsonAssetToObject<Achievement>($"Presets/achievements/{index_obj}"));
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
}

[System.Serializable]
public class AchievementsIDIndex
{
    public List<string> index;
}
