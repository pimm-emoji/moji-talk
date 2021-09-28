using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The IngameDataManager Class
    IngameDataManager will be instantiated when Level is selected and destroyd when Level ends.
*/
public class IngameDataManager : MonoBehaviour
{
    /// <summary>
    /// Call <c>IngameDataManager.instance</c> when need to use <c>IngameDataManager</c>.
    /// </summary>
    public static IngameDataManager instance = null;

    public string levelID;
    public Level level;  
    public List<Profile> participants;
    public Flow flow;
    public UserData userData;

    void Awake()
    {
        // Set IngameDataManager unique.
        if (instance == null) instance = this;  
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject); // 이 오브젝트는 다른 씬으로 넘어가도 파괴되지 않음

        LoadLevelList();
        UserDataManager.InitStorage();
        userData = UserDataManager.LoadStorage();
    }


    /* === entire data === */

    public List<string> levelIndexList;
    public void LoadLevelList()
    {
        levelIndexList = JsonIO.LoadJsonAssetToObject<LevelIndexWrapper>("Presets/levels").levels;
    }


    /* === each data === */

    public void SetLevelID(string LevelID) { levelID = LevelID; }  //string 형식의 LevelID를 지정하거나 리턴받음
    // public void LoadLevelID() {}
    public string GetLevelID() { return levelID; }

    public void SetLevel(Level Level) 
    {
        level = Level;
    }
    public void LoadLevel()
    {
        LoadLevel(levelID);
    }

    public void LoadLevel(string LevelID)
    {
        Dictionary<string, Level> presetDict = new Dictionary<string, Level>();
        LoadLevelList();
        //print(JsonIO.LoadJsonAssetToObject<LevelIndexWrapper>("Presets/levels"));
        foreach (string levelIndex in levelIndexList)
        {
            Level levelConfigs = JsonIO.LoadJsonAssetToObject<Level>($"Presets/levels/{levelIndex}/configs");
            presetDict.Add(levelIndex, levelConfigs);
        }
        level = presetDict[LevelID];
    }
    public Level GetLevel()
    {
        return level;
    }
    public Level GetLevel(string LevelID)
    {
        LoadLevel(LevelID); 
        return level;
    }

    public void SetLevelFlow(Flow Flow)
    {
        flow = Flow;
    }
    public void LoadLevelFlow()
    {
        LoadLevelFlow(levelID);
    }
    public void LoadLevelFlow(string LevelID) 
    {
        flow = JsonIO.LoadJsonAssetToObject<Flow>($"Presets/levels/{LevelID}/flow");
    }
    public Flow GetLevelFlow()
    {
        return flow;
    }

    public void SetParticipants(List<Profile> Participants)
    {
        participants = Participants;
    }
    public void LoadParticipants()
    {
        LoadParticipants(level);
    }
    public void LoadParticipants(Level level) {
        participants = new List<Profile>();
        foreach (string Participant in level.participants)
        {
            participants.Add(
                JsonIO.LoadJsonAssetToObject<Profile>($"Presets/Profiles/{Participant}")
            );
        }
    }
    public void LoadParticipants(List<string> Participants)
    { 
        participants = new List<Profile>();
        foreach (string Participant in Participants)
        {
            participants.Add(
                JsonIO.LoadJsonAssetToObject<Profile>($"Presets/Profiles/{Participant}")
            );
        }
    }
    public List<Profile> GetParticipants() { return participants; }

    public void LoadLevelEntire(string LevelID) { levelID = LevelID; LoadLevelEntire(); } //LoadLevel 함수. 레벨데이터, 레벨플로우, participants를 모두 로드한다
    public void LoadLevelEntire()
    {
        LoadLevel(levelID);
        LoadLevelFlow(levelID);
        LoadParticipants(level);
    }


    [ContextMenu("DebugLoadLevelEntire")] public void DebugLoadLevel() { LoadLevelEntire("first"); }
    [ContextMenu("DebugLoadLevelFlow")] public void DebugLoadLevelFlow() { SetLevelID("first"); LoadLevelFlow(); }
    [ContextMenu("DebugLoadParticipants")] public void DebugLoadParticipants() { LoadParticipants(); }
}

[System.Serializable]
public class LevelIndexWrapper
{
    public List<string> levels;
}
