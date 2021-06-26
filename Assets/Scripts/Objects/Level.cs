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
/// <code>
/// Level level = new Level("emote", new Branch());
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
/// </summary>
[System.Serializable]
class Level
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

    public Level(){}
    public Level(string Type, Branch Branch)
    {
        type = Type;
        branch = Branch;
    }
}

/*
    The LevelEmote Class
    Contains level data when level type is "emote"
*/
/// <summary>
/// The LevelEmote Class.
/// Contains level data when level type is "emote".
/// <example>
/// <code>
/// LevelEmote levelEmote = new LevelEmote();
/// levelEmote.branch = new Branch();
/// levelEmote.duration = 1000;
/// levelEmote.generates = new EmojiGenerations();
/// </code>
/// <code>
/// LevelEmote levelEmote = new LevelEmote(new Branch(), 1000, new EmojiGenerations());
/// </code>
/// </example>
/// <item>
/// <term>branch</term>
/// <description>The branch of each level.</description>
/// </item>
/// <item>
/// <term>duration</term>
/// <description>LevelEmote duration.</description>
/// </item>
/// <item>
/// <term>generates</term>
/// <description>Data about generating emoji.</description>
/// </item>
/// </summary>
[System.Serializable]
class LevelEmote : Level
{
    /// <summary>
    /// LevelEmote duration.
    /// </summary>
    public float duration;

    /// <summary>
    /// Data about generating emoji.
    /// </summary>
    public EmojiGenerations generates;

    public LevelEmote()
    {
        type = "emote";
    }
    public LevelEmote(Branch Branch, float Duration, EmojiGenerations Generates)
    {
        type = "emote";
        branch = Branch;
        duration = Duration;
        generates = Generates;
    }
}

/*
    The LevelChatting Class
    Contains level data when level type is "chatting"
*/
/// <summary>
/// The LevelChatting Class.
/// Contains level data when level type is "chatting".
/// <example>
/// <code>
/// LevelChatting levelChatting = new LevelChatting();
/// levelChatting.branch = new Branch();
/// levelChatting.chats = MESSAGE_LIST;
/// </code>
/// <code>
/// LevelChatting levelChatting = new LevelChatting(new Branch(), MESSAGE_LIST);
/// </code>
/// </example>
/// <item>
/// <term>branch</term>
/// <description>The branch of each level.</description>
/// </item>
/// <item>
/// <term>chats</term>
/// <description>List of Message objects.</description>
/// </item>
/// </summary>
[System.Serializable]
class LevelChatting : Level
{
    /// <summary>
    /// List of Message objects.
    /// </summary>
    public List<Message> chats;
    
    public LevelChatting()
    {
        type = "chatting";
    }
    public LevelChatting(Branch Branch, List<Message> Chats)
    {
        type = "chatting";
        branch = Branch;
        chats = Chats;
    }
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
class Flow
{
    /// <summary>
    /// List of <c>Level</c> objects.
    /// </summary>
    public List<Level> flow;

    public Flow(){}
    public Flow(List<Level> Flow)
    {
        flow = Flow;
    }
}
