using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Flow
{
    public List<EachChildFlow> flow;
}

[System.Serializable]
public class EachChildFlow
{
    public string type;
    public Branch branch;
    public float duration;
    public EmojiGenerations generates;
    public List<Message> chats;
    public string endingID;
}

[System.Serializable]
public class Branch
{
    public List<float> divider;
    public List<int> index;

    public Branch()
    {
        divider = new List<float>();
        index = new List<int>();
    }
    public Branch(List<float> Divider, List<int> Index)
    {
        divider = Divider;
        index = Index;
    }
}

[System.Serializable]
public class EmojiGenerations
{
    public int[] ratio = {1, 1};
    public List<Emoji> positiveEmojis;
    public List<Emoji> negativeEmojis;

    public EmojiGenerations()
    {
        positiveEmojis = new List<Emoji>();
        negativeEmojis = new List<Emoji>();
    }
    public EmojiGenerations(int[] Ratio)
    {
        ratio = Ratio;
        positiveEmojis = new List<Emoji>();
        negativeEmojis = new List<Emoji>();
    }
    public EmojiGenerations(List<Emoji> PositiveEmojis, List<Emoji> NegativeEmojis)
    {
        positiveEmojis = PositiveEmojis;
        negativeEmojis = NegativeEmojis;
    }
    public EmojiGenerations(int[] Ratio, List<Emoji> PositiveEmojis, List<Emoji> NegativeEmojis)
    {
        ratio = Ratio;
        positiveEmojis = PositiveEmojis;
        negativeEmojis = NegativeEmojis;
    }
}

[System.Serializable]
public class Message
{
    public string author;
    public string type;
    public string content;
    public float delay;

    public Message()
    {
        author = new string();
        type = new string();
        content = new string();
        delay = new string();
    }
    public Message(string Author, string Type, string Content, string Delay)
    {
        author = Author;
        type = Type;
        content = Content;
        delay = Delay;
    }
}
