using System.Collections;
using UnityEngine;

public class EmojiBridge : MonoBehaviour
{
    public GameObject emojiObject;
    
    public void Init(string EmojiID)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(
            Configs.ResourceEmojiPath + EmojiID
        );
    }

    public void DestroyTrigger()
    {}
}
