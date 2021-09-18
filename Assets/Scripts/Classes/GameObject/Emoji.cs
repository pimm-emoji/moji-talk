using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Emoji
{
    public string id;
    public string asset;
    public float ondestroy;
    public Sprite sprite;

    public Emoji(string ID, string Asset, float OnDestroy)
    {
        id = ID;
        asset = Asset;
        ondestroy = OnDestroy;
    }

    public static Emoji LoadEmoji(string emojiID)
    {
        Emoji newEmoji = AssetLoader.LoadJsonToObject(Path.Combine("Emojis", "Meta", $"{emojiID}")).ToObject<Emoji>();
        newEmoji.sprite = Resources.Load<Sprite>(newEmoji.asset);
        return newEmoji;
    }

    // [ContextMenu("Debug LoadEmoji")] void DebugLoadEmoji() { Emoji.LoadEmoji("thinking"); }
}
