using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public string id;
    public string name;
    public string desc;
    public string img;
    public string type;
    public List<string> participants;
    public bool isCleared; // using at savedata.
    public List<Ending> endings;
    public List<string> usingEmojis;

    public LevelData(string ID, string Name, List<Ending> Endings)
    {
        id = ID;
        name = Name;
        endings = Endings;
    }
    public LevelData(string ID, string Name, string Desc, string Img, string Type, List<string> Participants, List<Ending> Endings){
        id = ID;
        name = Name;
        desc = Desc;
        img = Img;
        type = Type;
        participants = Participants;
        endings = Endings;
    }
}

[System.Serializable]
public class Ending
{
    public string id; // a
    public string name; // Memory of 'A' Time
    public Ending(string ID)
    {
        id = ID;
    }
    public Ending(string ID, string Name)
    {
        id = ID;
        name = Name;
    }
}
