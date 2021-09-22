using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelBoxWrapperController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public string levelID;
    public LevelBoxWrapper levelboxWrapper;
    public Image imageComponent;
    bool nextscene = false;
    bool fadedo = false;

    public void Awake()
    {
        imageComponent = GetComponent<Image>();
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("IngameScene");
    }
    public void Init(string ID, string Title, string Description, string Collections)
    {
        levelID = ID;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageComponent.color = new Color32(110, 150, 198, 200);
        AudioManager.instance.PlaySFX("touch");
        if(levelboxWrapper.title.text == "키사모")   //해당 부분에 가져다 대면 재생
        {
            AudioManager.instance.StopBGM();
            AudioManager.instance.PlayBGM("stage1");
        }
        else if(levelboxWrapper.title.text == "Aimless")
        {
            AudioManager.instance.StopBGM();
            AudioManager.instance.PlayBGM("stage2");
        }
        else if(levelboxWrapper.title.text == "Debug Scene")
        {
            AudioManager.instance.StopBGM();
            AudioManager.instance.PlayBGM("stage3");
        }
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.PlaySFX("click");
        GameManager.instance.nowLevelID = levelID;
        fadecontroller.instance.Fadeout();
       

        Invoke("SceneChange", 2);
        
        


    }
    public void OnPointerExit(PointerEventData eventData)
    {
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlayBGM("background");
        imageComponent.color = new Color32(0, 41, 64, 143);
    }

    [ContextMenu("Debug Init")] void DebugInit() { Init("first", "Time Remastered", "Soundtrack", "Epic Mountain Music"); }
}

[System.Serializable]
public class LevelBoxWrapper
{
    public Text title;
    public Text description;
    public Text collections;
    public Image image;
}
