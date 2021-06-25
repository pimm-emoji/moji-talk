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
/// </code>
/// <code>
/// Level level = new Level("emote");
/// </code>
/// </example>
/// <item>
/// <term>type</term>
/// <description>Type of level.</description>
/// </item>
/// </summary>
[System.Serializable]
class Level
{
    /// <summary>
    /// The type of level.
    /// </summary>
    public string type;

    public Level(){}
    public Level(string Type)
    {
        type = Type;
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
/// levelEmote.duration = 1000;
/// levelEmote.generates = new EmojiGenerations();
/// </code>
/// <code>
/// LevelEmote levelEmote = new LevelEmote(1000, new EmojiGenerations());
/// </code>
/// </example>
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
    public LevelEmote(float Duration, EmojiGenerations Generates)
    {
        type = "emote";
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
/// levelChatting.chats = MESSAGE_LIST;
/// </code>
/// <code>
/// LevelChatting levelChatting = new LevelChatting(MESSAGE_LIST);
/// </code>
/// </example>
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
    public LevelChatting(List<Message> Chats)
    {
        type = "chatting";
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
/// <description>List of level.</description>
/// </item>
/// </example>
/// </summary>
[System.Serializable]
class Flow
{
    public List<Level> flow;

    public Flow(){}
    public Flow(List<Level> Flow)
    {
        flow = Flow;
    }
}
