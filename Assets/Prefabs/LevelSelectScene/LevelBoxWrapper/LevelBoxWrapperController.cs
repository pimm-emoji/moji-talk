using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBoxWrapperController : MonoBehaviour
{
    public LevelBoxWrapper levelboxWrapper;

    public void Init(string Title, string Description, string Collections)
    {
        SetContents(Title, Description, Collections);
    }
    
    public void SetContents(string Title, string Description, string Collections)
    {
        SetTitle(Title);
        SetDescription(Description);
        SetCollections(Collections);
    }
    public void SetContents(string Title, string Description, string Collections, Sprite ImageSprite)
    {
        SetTitle(Title);
        SetDescription(Description);
        SetCollections(Collections);
    }
    public void SetTitle(string Title) { levelboxWrapper.title.text = Title; }
    public void SetDescription(string Description) { levelboxWrapper.description.text = Description; }
    public void SetCollections(string Collections) { levelboxWrapper.collections.text = Collections; }
    public void SetImage(Sprite ImageSprite) { levelboxWrapper.image.sprite = ImageSprite; }

    [ContextMenu("Debug Init")] void DebugInit() { Init("Time Remastered", "Soundtrack", "Epic Mountain Music"); }
}

[System.Serializable]
public class LevelBoxWrapper
{
    public Text title;
    public Text description;
    public Text collections;
    public Image image;
}
