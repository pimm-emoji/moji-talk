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
        DontDestroyOnLoad(this.gameObject); // 이 오브젝트는 다른 씬으로 넘어가도 파괴되지 않음
    }

    public void SetLevelID(string LevelID) { levelID = LevelID; }  //string 형식의 LevelID를 지정하거나 리턴받음
    // public void LoadLevelID() {}
    public string GetLevelID() { return levelID; }

    public void SetLevelData(LevelData LevelData) { levelData = LevelData; }//LevelData 형식의 leveldata를 설정하거나 로드하거나 리턴받음
    public void LoadLevelData() { LoadLevelData(levelID); }
    public void LoadLevelData(string LevelID)
    { levelData = JObject.Parse(File.ReadAllText(Configs.LevelIndexPath))[LevelID].ToObject<LevelData>(); }
    public LevelData GetLevelData() { return levelData; }
    public LevelData GetLevelData(string LevelID) { LoadLevelData(LevelID); return levelData; }

    public void SetLevelFlow(List<Level> Flow) { flow = Flow; } // 리스트<레벨> 형식의 flow를 지정하거나 로드하거나 리턴받음
    public void LoadLevelFlow() { LoadLevelFlow(levelID); }
    public void LoadLevelFlow(string LevelID) 
    {
        flow = PresetController.LoadSingleDepth<Level>(
            PresetController.LoadJsonToArray(Path.Combine(Configs.LevelDirPath, LevelID, "flow.json"))
        );
    }
    public List<Level> GetLevelFlow() { return flow; }

    public void SetParticipants(List<Profile> Participants) { participants = Participants; } //리스트<프로필> 형태의 participants를 지정하거나 로드하거나 리턴받음
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

    public void LoadLevel(string LevelID) { levelID = LevelID; LoadLevel(); } //LoadLevel 함수. 레벨데이터, 레벨플로우, participants를 모두 로드한다
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
