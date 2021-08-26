using System.Collections;
using UnityEngine;

public class EmojiBridge : MonoBehaviour
{
    public Emoji emoji;
    
    [ContextMenu("Debug")] public void DebugEmoji()
    {
        emoji = Emoji.LoadEmoji("apple");
    }

    public void Init(Emoji Emoji)
    {
        emoji = Emoji;
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(
            Configs.ResourceEmojiPath + Emoji.asset
        );
    }

    public void DestroyTrigger()
    {}
}
