using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    The IngamePlayScene
*/
public class IngamePlayScene : MonoBehaviour
{    
    public GameObject MessageWrapperPrefab;
    public GameObject ScrollViewContent;
    public float Spacing = 15;
    public int HorizontalPadding = 40;
    List<Level> flow;

    void Start()
    {
        IngameDataManager.instance.LoadLevel("debug");
        flow = IngameDataManager.instance.GetLevelFlow();
        VerticalLayoutGroup VerticalLayoutGroup = ScrollViewContent.GetComponent<VerticalLayoutGroup>();
        VerticalLayoutGroup.spacing = Spacing;
        VerticalLayoutGroup.padding = new RectOffset(HorizontalPadding, HorizontalPadding, 0, 0);
        StartCoroutine(ProcessingFlows());
    }

    IEnumerator ProcessingFlows()
    {
        bool Flag = true;
        int i = 0; // index
        while (Flag)
        {
            if (flow[i].type == "chatting")
            {
                foreach(var message in flow[i].chats)
                {
                    // Processing Message
                    print(message.content);
                    GameObject newObject = Instantiate(MessageWrapperPrefab);
                    newObject.transform.SetParent(GameObject.Find("Content").transform);
                    newObject.GetComponent<MessageWrapperController>().Init(message.content);
                    var newObjectRectSize = newObject.GetComponent<MessageWrapperController>().GetSize();
                    AddScrollViewContentHeight(newObjectRectSize.y);
                    newObject.GetComponent<RectTransform>().sizeDelta = newObjectRectSize;

                    yield return new WaitForSeconds(message.delay / 1000);
                }
                i = flow[i].branch.index[0];
            }
            else if (flow[i].type == "emote")
            {
                // Processing Emote Scene

                yield return new WaitForSeconds(flow[i].duration / 1000);
            }
            else if (flow[i].type == "end")
            {
                Flag = false;
            }
        }
    }

    void AddScrollViewContentHeight(float height)
    {
        Vector2 RectSize = ScrollViewContent.GetComponent<RectTransform>().sizeDelta;
        ScrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(RectSize.x, RectSize.y + height + Spacing);
    }
}
