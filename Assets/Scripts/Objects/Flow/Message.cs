using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The Message Class
    Contains data of each message
*/
/// <summary>
/// The Message Class.
/// Contains data of each message.
/// <example>
/// <code>
/// Message message = new Message();
/// message.author = "player";
/// message.type = "message";
/// message.content = "Hello.";
/// message.delay = 1000;
/// </code>
/// <code>
/// Message message = new Message("player", "message", "Hello.", 1000);
/// </code>
/// </example>
/// <item>
/// <term>author</term>
/// <description>ID of author.</description>
/// </item>
/// <item>
/// <term>type</term>
/// <description>Type of message.</description>
/// </item>
/// <item>
/// <term>content</term>
/// <description>Content of message.</description>
/// </item>
/// <item>
/// <term>delay</term>
/// <description>Delay of message.</description>
/// </item>
/// </summary>
[System.Serializable]
class Message
{
    /// <summary>
    /// ID of author.
    /// </summary>
    /// <remarks>
    /// ID must be defined on Profiles Preset or "player".
    /// </remarks>
    public string author;

    /// <summary>
    /// Type of message.
    /// </summary>
    /// <remarks>
    /// Type must be <c>"message"</c>, <c>"emoji"</c> or <c>"system"</c>.
    /// </remarks>
    public string type;

    /// <summary>
    /// Content of message.
    /// <br />
    /// If this message's type is <c>"emoji"</c>,
    /// content must be emoji's id.
    /// <br />
    /// If this message's type is <c>"system"</c>,
    /// content must be <c>"join"</c>, <c>"exit"</c> or other events.
    /// </summary>
    public string content;

    /// <summary>
    /// Interval delay before the next message occurs.
    /// </summary>
    public float delay { get; set; }

    public Message(){}
    public Message(string Author, string Type, string Content, float Delay)
    {
        author = Author;
        type = Type;
        content = Content;
        delay = Delay;
    }
}

