using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Profiles
{
    public List<Profile> profiles;
}

[System.Serializable]
public class Profile
{
    public string id;
    public string name;
    public string desc;
    public string imgAssetName;

    public Profile()
    {
        id = new string();
        name = new string();
        desc = new string();
        imgAssetName = new string();
    }
    public Profile(string ID, string Name, string Desc, string ImgAssetName)
    {
        id = ID;
        name = Name;
        desc = Desc;
        imgAssetName = ImgAssetName;
    }
}
