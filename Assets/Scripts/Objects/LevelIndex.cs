using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The LevelInformation Class
    Contains Single Level Flow (Stage) Data
*/
/// <summary>
/// The LevelInformation Class.
/// Contains Single Level Flow (Stage) Data.
/// Same as <c>levels.json</c>.
/// <example>
/// <code>
/// LevelInformation levelInformation = new LevelInformation();
/// levelInformation.id = "first";
/// levelInformation.type = "single";
/// levelInformation.participants = STRING_LIST;
/// </code>
/// <code>
/// LevelInformation levelInformation = new LevelInformation("first", "single", STRING_LIST);
/// </code>
/// </example>
/// <item>
/// <term>id</term>
/// <description>Internal ID of level flow.</description>
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
class LevelInformation
{
    /// <summary>
    /// Internal ID of level flow.
    /// </summary>
    public string id;

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

    public LevelInformation(){}
    public LevelInformation(string ID, string Type, List<string> Participants){
        id = ID;
        type = Type;
        participants = Participants;
    }
}

// Todo: Edit
[System.Serializable]
class LevelIndex
{
    public List<LevelInformation> list;
}
