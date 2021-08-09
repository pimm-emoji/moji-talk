using System.Collections;
using UnityEngine;

public class EmojiBridge : MonoBehaviour
{
    public GameObject emojiObject;
    public Emoji emoji;
    
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
