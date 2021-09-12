using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string id;
    public string name;
    public string desc;
    public string imgAssetName;
    public string type;
    public List<string> participants;
    public bool isCleared;
    public List<Ending> endings;
    public List<string> usingEmojis;

    public Level()
    {
        id = new string();
        name = new string();
        desc = new string();
        imgAssetName = new string();
        type = new string();
        participants = new List<string>();
        isCleared = new bool();
        endings = new List<Ending>();
        usingEmojis = new List<string>();
    }
    public Level(string ID, string Name, List<Ending> Ending)
    {
        id = ID;
        name = Name;
        endings = Endings;
    }
    public Level(string ID, string Name, string Desc, string ImgAssetName, string Type, List<string> Participants, List<Ending> Endings)
    {
        id = ID;
        name = Name;
        desc = Desc;
        imgAssetName = ImgAssetName;
        type = Type;
        participants = Participants;
        endings = Endings;
    }
}

[System.Serializable]
public class Ending
{
    public string id;       // 'b'
    public string name;     // or not to [B]e
    public Ending()
    {
        id = new string();
        name = new string();
    }
    public Ending(string ID, string Name)
    {
        id = ID;
        name = Name;
    }
}