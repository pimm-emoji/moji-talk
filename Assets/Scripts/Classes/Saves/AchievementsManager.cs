using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementsManager : MonoBehaviour
{
    public List<Achievement> achievements;
    public Ending ending;

    void Awake()
    {
        LoadAchievements();
        //CheckCondition();
        Debug.Log(achievements[0].id);
    }

    public void Refresh()
    {
        LoadAchievements();
        //CheckCondition();
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
        for(int i = 0; i< achievements.Count; i++){    
            if (x => x.id == "hawkeye_1")
            {
                if(GameManager.instance.bad + GameManager.instance.miss < 20){
                   achievements[i].condition = true;}
                else{ achievement[i].condition = false;}
            }


            else if(x=> x.id == "MemoryofAtime")    
            {
                Ending ending = IngameDataManager.instance.level.endings.Find(x => x.id == GameManager.instance.endingID);
                if(ending.name == "Memory of 'A' Time")
                {
                    achievements[i].condition = true;
                }
                else { achievement[i].condition = false; }
            }


            else if(x=> x.id == "gameover")    
            {
                if(중간에 game over 되었을 시)
                {
                    achievements[i].condition = true;
                }
                else { achievement[i].condition = false; }
            }

            else if(x=> x.id == "badend")    
            {
                if(최종 엔딩이 bad 엔딩일 시)
                {
                    achievements[i].condition = true;
                }
                else { achievement[i].condition = false; }
            }      

            else if(x => x.id == "pumpkin")
            {
                if(최종 엔딩이 good 엔딩이고, 분기별 엔딩 점수 중 1번째가 가장 높을 때)
                {
                    achievements[i].condition = true;
                }
                else { achievement[i].condition = false;}
                    
            }

            else if(x=> x.id =="rich")
            {
                if(최종 엔딩이 good 엔딩이고, 분기별 엔딩 점수가 2번째가 가장 높을 때)
                {
                     achievements[i].condition = true;
                }
                else { achievement[i].condition = false;}
                    
            }

            else if(x=> x.id =="justice")
            {
                if(최종 엔딩이 good 엔딩이고, 분기별 엔딩 점수가 3번째가 가장 높을 때)
                {
                     achievements[i].condition = true;
                }
                else { achievement[i].condition = false;}
                    
            }
            

        }

    */
}

[System.Serializable]
public class AchievementsIDIndex
{
    public List<string> index;
}
