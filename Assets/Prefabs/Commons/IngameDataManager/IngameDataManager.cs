using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

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
    public LevelData levelData;
    public List<Profile> participants;
    public List<Level> flow;

    void Awake()
    {
        // Set IngameDataManager unique.
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLevelID(string LevelID) { levelID = LevelID; }
    // public void LoadLevelID() {}
    public string GetLevelID() { return levelID; }

    public void SetLevelData(LevelData LevelData) { levelData = LevelData; }
    public void LoadLevelData() { LoadLevelData(levelID); }
    public void LoadLevelData(string LevelID)
    { levelData = JObject.Parse(File.ReadAllText(Configs.LevelIndexPath))[LevelID].ToObject<LevelData>(); }
    public LevelData GetLevelData() { return levelData; }
    public LevelData GetLevelData(string LevelID) { LoadLevelData(LevelID); return levelData; }

    public void SetLevelFlow(List<Level> Flow) { flow = Flow; }
    public void LoadLevelFlow() { LoadLevelFlow(levelID); }
    public void LoadLevelFlow(string LevelID) 
    {
        flow = PresetController.LoadSingleDepth<Level>(
            PresetController.LoadJsonToArray(Path.Combine(Configs.LevelDirPath, LevelID, "flow.json"))
        );
    }
    public List<Level> GetLevelFlow() { return flow; }

    public void SetParticipants(List<Profile> Participants) { participants = Participants; }
    public void LoadParticipants() { LoadParticipants(levelData); }
    public void LoadParticipants(LevelData LevelData) {
        participants = new List<Profile>();
        foreach (string Participant in LevelData.participants)
        {
            participants.Add(PresetController.LoadJsonToObject(Path.Combine(Configs.PresetProfileDirPath, $"{Participant}.json")).ToObject<Profile>());
        }
    }
    public void LoadParticipants(List<string> Participants)
    { 
        participants = new List<Profile>();
        foreach (string Participant in Participants)
        {
            participants.Add(PresetController.LoadJsonToObject(Path.Combine(Configs.PresetProfileDirPath, $"{Participant}.json")).ToObject<Profile>());
        }
    }
    public List<Profile> GetParticipants() { return participants; }

    public void LoadLevel(string LevelID) { levelID = LevelID; LoadLevel(); }
    public void LoadLevel()
    {
        LoadLevelData(levelID);
        LoadLevelFlow(levelID);
        LoadParticipants(levelData);
    }


    [ContextMenu("DebugLoadLevelData")] public void DebugLoadLevelData() { LoadLevelData("first"); }
    [ContextMenu("DebugLoadLevelFlow")] public void DebugLoadLevelFlow() { SetLevelID("first"); LoadLevelFlow(); }
    [ContextMenu("DebugLoadParticipants")] public void DebugLoadParticipants() { LoadParticipants(); }
    [ContextMenu("DebugLoadLevel")] public void DebugLoadLevel() { LoadLevel("first"); }
}
