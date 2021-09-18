using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public string userIcon;
    public List<string> unlockedLevels;
    public List<Level> unlockedLevelData;
    
    public UserData()
    {
        userName = "";
        userIcon = "";
        unlockedLevels = new List<string>();
        unlockedLevelData = new List<Level>();
    }
}
