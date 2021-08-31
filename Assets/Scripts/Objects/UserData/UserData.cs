using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public string userIcon;
    public List<string> unlockedLevels;
    public List<LevelData> unlockedLevelData;
}