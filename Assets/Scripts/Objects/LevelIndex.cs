using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The LevelData Class
    Contains Single Level Flow (Stage) Data
*/
/// <summary>
/// The LevelData Class.
/// Contains Single Level Flow (Stage) Data.
/// Same as <c>levels.json</c>.
/// <example>
/// <code>
/// LevelData levelData = new LevelData();
/// LevelData.id = "first";
/// LevelData.name = "키사모";
/// LevelData.desc = "키위를 사랑하는 사람들의 모임";
/// LevelData.img = "kiwi.png";
/// LevelData.type = "single";
/// LevelData.participants = STRING_LIST;
/// </code>
/// <code>
/// LevelData levelData = new LevelData("first", "키사모", "키위를 사랑하는 사람들의 모임", "kiwi.png", "single", STRING_LIST);
/// </code>
/// </example>
/// <item>
/// <term>id</term>
/// <description>Internal ID of level flow.</description>
/// </item>
/// <item>
/// <term>name</term>
/// <description>Name that will be displayed.</description>
/// </item>
/// <item>
/// <term>desc</term>
/// <description>Description that will be displayed.</description>
/// </item>
/// <item>
/// <term>img</term>
/// <description>Image path that will be displayed.</description>
/// </item>
/// <item>
/// <term>type</term>
/// <description>Type of chatting group.</description>
/// </item>
/// <item>
/// <term>participants</term>
/// <description>ID list of participants</description>
/// </item>
/// </summary>
/// <remarks>
/// <c>type</c> must be <c>"single"</c> or <c>"group"</c>.
/// </remarks>
[System.Serializable]
public class LevelData
{
    /// <summary>
    /// Internal ID of level flow.
    /// </summary>
    public string id;

    /// <summary>
    /// Name that will be displayed.
    /// </summary>
    public string name;

    /// <summary>
    /// Description that will be displayed.
    /// </summary>
    public string desc;

    /// <summary>
    /// Image Path that will be displayed.
    /// </summary>
    public string img;

    /// <summary>
    /// Type of chatting group.
    /// </summary>
    /// <remarks>
    /// <c>type</c> must be <c>"single"</c> or <c>"group"</c>.
    /// </remarks>
    public string type;

    /// <summary>
    /// ID list of participants.
    /// </summary>
    public List<string> participants;

    public LevelData(string ID, string Name, string Desc, string Img, string Type, List<string> Participants){
        id = ID;
        name = Name;
        desc = Desc;
        img = Img;
        type = Type;
        participants = Participants;
    }
}
