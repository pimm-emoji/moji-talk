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
        id = "";
        name = "";
        desc = "";
        imgAssetName = "";
    }
    public Profile(string ID, string Name, string Desc, string ImgAssetName)
    {
        id = ID;
        name = Name;
        desc = Desc;
        imgAssetName = ImgAssetName;
    }
}
