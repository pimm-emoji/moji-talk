using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The Profile Class
    Contains data of each person
*/
/// <summary>
/// The Profile Class.
/// Contains data of each character
/// <example>
/// <code>
/// Profile profile = new Profile();
/// profile.id = "dopamine";
/// profile.name = "Dr. Dopamine";
/// profile.desc = "Korea's best docter";
/// profile.img = "dopamine.png";
/// </code>
/// <code>
/// Profile profile = new Profile("dopamine", "Dr. Dopamine", "Korea's best docter", "dopamine.png");
/// </code>
/// </example>
/// <item>
/// <term>id</term>
/// <description>ID of character.</description>
/// </item>
/// <item>
/// <term>name</term>
/// <description>Name of character.</description>
/// </item>
/// <item>
/// <term>desc</term>
/// <description>Description of character.</description>
/// </item>
/// <item>
/// <term>img</term>
/// <description>Filename of character image.</description>
/// </item>
/// </summary>
[System.Serializable]
class Profile
{
    public string id;
    public string name;
    public string desc;
    public string img;

    public Profile(){}
    public Profile(string ID, string Name, string Desc, string Img)
    {
        id = ID;
        name = Name;
        desc = Desc;
        img = Img;
    }
}

/*
    The Profiles Class
    Contains Profile List
*/
/// <summary>
/// The Profiles Class.
/// Contains Profile List.
/// <example>
/// <code>
/// Profiles profiles = new Profiles();
/// profiles.list = PROFILE_LIST;
/// </code>
/// <code>
/// Profiles profiles = new Profiles(PROFILE_LIST);
/// </code>
/// </example>
/// <item>
/// <term>list</term>
/// <description>List of Profile object.</description>
/// </item>
/// </summary>
[System.Serializable]
class Profiles
{
    public List<Profile> list;

    public Profiles(){}
    public Profiles(List<Profile> List)
    {
        list = List;
    }
}
