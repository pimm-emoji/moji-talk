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

    void Start()
    {
        // Set IngameDataManager unique.
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLevelID(string LevelID) { levelID = LevelID; }
    public string GetLevelID() { return levelID; }

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
    public void LoadParticipants(List<string> Participants)
    { // 사용하는것만 로드시킬 수 있게 할 것
        participants = new List<Profile>();
        foreach (string Participant in Participants)
        {
            participants.Add(
                JObject.Parse(File.ReadAllText(
                    Path.Combine(Configs.PresetProfileDirPath, Participant)
                ).ToObject<Profile>())
            );
        }
    }
    public List<Profile> GetParticipants() { return participants; }

    public void LoadLevel(string LevelID)
    {
        levelID = LevelID;
        LoadLevel();
    }
    public void LoadLevel()
    {}
}
