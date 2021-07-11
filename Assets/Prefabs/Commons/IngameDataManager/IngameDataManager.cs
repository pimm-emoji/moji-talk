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
    public LevelData levelData;
    public List<Profile> participants;
    public Flow flow;

    void Start()
    {
        // Set IngameDataManager unique.
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLevelID(string LevelID) { levelID = LevelID; }
    public void LoadLevelID() {}
    public string GetLevelID() { return levelID; }

    public void SetLevelFlow(Flow Flow) { flow = Flow; }
    public void LoadLevelFlow() { LoadLevelFlow(levelID); }
    public void LoadLevelFlow(string LevelID) 
    {}
    public void GetLevelFlow() {}

    public void SetParticipants() {}
    public void LoadParticipants() {}
    public void GetParticipants() {}

    public void LoadLevel() {}
}
