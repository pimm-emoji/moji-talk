using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The Level Class
*/
/// <summary>
/// The Level Class.
/// <example>
/// <code>
/// Level level = new Level();
/// level.type = "emote";
/// level.branch = new Branch();
/// </code>
/// </example>
/// <item>
/// <term>type</term>
/// <description>The type of level.</description>
/// </item>
/// <item>
/// <term>branch</term>
/// <description>The branch of each level.</description>
/// </item>
/// <item>
/// <term>duration</term>
/// <description>The duration of LevelEmote.</description>
/// </item>
/// <item>
/// <term>generates</term>
/// <description>The data about generating emoji.</description>
/// </item>
/// <item>
/// <term>chats</term>
/// <description>The list of Message objects.</description>
/// </item>
/// </summary>
[System.Serializable]
public class Level
{
    /// <summary>
    /// The type of level.
    /// </summary>
    /// <remarks>
    /// <c>type</c> must be <c>"emote"</c>, <c>"chatting"</c> or <c>"end"</c>
    /// </remarks>
    public string type;

    /// <summary>
    /// The branch of each level.
    /// </summary>
    public Branch branch;

    /*
        Uses when type is LevelEmote
    */

    /// <summary>
    /// LevelEmote duration.
    /// </summary>
    public float duration;

    /// <summary>
    /// Data about generating emoji.
    /// </summary>
    public EmojiGenerations generates;

    /*
        Uses when type is LevelChatting
    */

    /// <summary>
    /// List of Message objects.
    /// </summary>
    public List<Message> chats;

    public string ending;
}

/*
    The Flow Class
    Contains whole level data that forms single stage
*/
/// <summary>
/// The Flow Class.
/// Contains whole level data that forms single stage.
/// <example>
/// <code>
/// Flow flow = new Flow();
/// flow.flow = LEVEL_LIST;
/// </code>
/// <code>
/// Flow flow = new Flow(LEVEL_LIST);
/// </code>
/// <item>
/// <term>flow</term>
/// <description>List of <c>Level</c> objects.</description>
/// </item>
/// </example>
/// </summary>
[System.Serializable]
public class Flow
{
    public List<Level> flow;

}
