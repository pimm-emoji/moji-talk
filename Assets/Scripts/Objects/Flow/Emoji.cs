using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The Emoji Class
    Contains data of emoji object
*/
/// <summary>
/// The Emoji Class.
/// Contains data of emoji object.
/// <example>
/// <code>
/// Emoji emoji = new Emoji();
/// emoji.id = "thumbsup";
/// emoji.asset = "thumbsup.png";
/// emoji.ondestroy = 1.0;
/// </code>
/// <code>
/// Emoji emoji = new Emoji("thumbsup", "thumbsup.png", 1.0);
/// </code>
/// </example>
/// <item>
/// <term>id</term>
/// <description>ID of emoji.</description>
/// </item>
/// <item>
/// <term>asset</term>
/// <description>Resource path of emoji.</description>
/// </item>
/// <item>
/// <term>ondestroy</term>
/// <description>Points when destroyed.</description>
/// </item>
/// </summary>
[System.Serializable]
public class Emoji
{

    /// <summary>
    /// ID(type) of emoji.
    /// </summary>
    public string id;

    /// <summary>
    /// Resource path of emoji.
    /// </summary>
    /// <remarks>
    /// Path: value of <c>Configs.EmojiPath + (this value)</c>
    /// </remarks>
    public string asset;

    /// <summary>
    /// Points when destroyed.
    /// </summary>
    public float ondestroy;
}

/*
    The EmojiGenerations Class
    Contains data about generating emoji
*/
/// <summary>
/// The EmojiGenerations Class.
/// Contains data about generating emoji.
/// <item>
/// <term>ratio</term>
/// <description>Positive/negative emoji rate.</description>
/// </item>
/// <item>
/// <term>emojis</term>
/// <description>Emoji object list arrays.</description>
/// </item>
/// </summary>
[System.Serializable]
public class EmojiGenerations
{
    /// <summary>
    /// Positive/negative emoji rate to be generated.
    /// </summary>
    public int[] ratio = {1, 1};

    /// <summary>
    /// Array that contains list of Emoji objects.
    /// </summary>
    public List<Emoji> positiveEmojis;
    public List<Emoji> negativeEmojis;
}
