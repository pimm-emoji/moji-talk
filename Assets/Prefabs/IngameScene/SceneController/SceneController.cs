using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public IngameSceneGameObjects objects;
    EmojiSpawner emojiSpawner;
    Flow flow;

    void Awake()
    {
        emojiSpawner = objects.emojiSpawner.GetComponent<EmojiSpawner>();
    }

    void Start()
    {
        if (string.IsNullOrEmpty(GameManager.instance.nowLevelID))
            GameManager.instance.nowLevelID = IngameConfig.defaultDebuggingLevelID;
        IngameDataManager.instance.LoadLevelEntire(GameManager.instance.nowLevelID);
        flow = IngameDataManager.instance.GetLevelFlow();
    }

    void Update()
    {
        FlowHandler();
    }

    public int[] flowIndex = {0, 0};
    public float previousFlowElapsed = 0;
    public bool triggerFlow = true;

    // Called Every Frame by Update Method
    void FlowHandler()
    {
        // Check time elapsed
        previousFlowElapsed += Time.deltaTime;
        if (flow.flow[flowIndex[0]].type == "chatting")
        {
            if (flow.flow[flowIndex[0]].chats[flowIndex[1]].delay / 1000 < previousFlowElapsed)
            {
                // Trigger Next Message
                if (flow.flow[flowIndex[0]].chats.Count -1 != flowIndex[1])
                {
                    flowIndex[1] += 1;
                }
                // Trigger Next Flow
                else
                {
                    flowIndex[0] += 1;
                    flowIndex[1] = 0;
                }
                // Initialize
                triggerFlow = true;
                previousFlowElapsed = 0;
            }
        }
        else if (flow.flow[flowIndex[0]].type == "emote")
        {
            if (flow.flow[flowIndex[0]].duration / 1000 < previousFlowElapsed) // Trigger Next Flow
            {
                // Stop Emoji Spawner Handler
                StopEmojiSpawner();
                // Trigger Next Flow
                Branch branch = flow.flow[flowIndex[0]].branch;
                branch.divider.Add(100);
                for (int i = 0; branch.divider[i] > GameManager.instance.branchIndexingScore; i++)
                {
                    flowIndex[0] = branch.index[i];
                    flowIndex[1] = 0;
                    break;
                }
                // Initialize
                flowIndex[0] += 1;
                triggerFlow = true;
                previousFlowElapsed = 0;
            }
        }

        // Trigger Flow when `triggerFlow` variable is true
        if (triggerFlow)
        {
            if (flow.flow[flowIndex[0]].type == "chatting")
            {
                // Add chatting
                AddChattingMessage(flow.flow[flowIndex[0]].chats[flowIndex[1]]);
            }
            else if (flow.flow[flowIndex[0]].type == "emote")
            {
                // Start Emoji Spawner Handler
                StartEmojiSpawner();
            }
            else if (flow.flow[flowIndex[0]].type == "end")
            {
                // Trigger Ending
                GameManager.instance.endingID = flow.flow[flowIndex[0]].ending;
                SceneManager.LoadScene("ResultScene");
            }
            // Initialize
            triggerFlow = false;
        }
    }

    void StartEmojiSpawner()
    {
        emojiSpawner.spawnswitch = true;
    }
    void StopEmojiSpawner()
    {
        emojiSpawner.spawnswitch = false;
        GameManager.instance.InitBranchScore();
    }

    void AddChattingMessage(Message message)
    {
        GameObject newObject = Instantiate(objects.chattingWrapperPrefab) as GameObject;
        newObject.GetComponent<ChattingWrapperController>().Init(message.author, message.content, message.author != "player" ? 0 : 1);
        objects.scrollViewContent.GetComponent<ScrollViewContentController>().AddChild(newObject, message.author != "player" ? 0 : 1);
        ScrollLogToBottom();
    }
    [ContextMenu("Clear Messages (Editor)")]
    void ClearMessagesEditor()
    {
        for (int i = 0; i < objects.scrollViewContent.transform.childCount; i++)
        {
            DestroyImmediate(objects.scrollViewContent.transform.GetChild(0).gameObject);
        }
    }
    [ContextMenu("Clear Messages (Play Mode or Runtime)")]
    void ClearMessages()
    {
        for (int i = 0; i < objects.scrollViewContent.transform.childCount; i++)
        {
            Destroy(objects.scrollViewContent.transform.GetChild(0).gameObject);
        }
    }
    void ScrollLogTo(float value) { objects.scrollViewObject.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, value); }
    [ContextMenu("Scroll Log to Top")] void ScrollLogToTop() { ScrollLogTo(1); }
    [ContextMenu("Scroll Log to Bottom")] void ScrollLogToBottom() { ScrollLogTo(0); }

    [ContextMenu("FadeIn Chatting ScrollView Wrapper")] void FadeInScrollView() { objects.scrollViewObject.GetComponent<Image>().CrossFadeAlpha(1f, ChattingConfig.scrollViewObjectFadeTime[0], false); }
    [ContextMenu("FadeOut Chatting ScrollView Wrapper")] void FadeOutScrollView() { objects.scrollViewObject.GetComponent<Image>().CrossFadeAlpha(0f, ChattingConfig.scrollViewObjectFadeTime[1], false); }
}

[System.Serializable]
public class IngameSceneGameObjects
{
    public GameObject chattingWrapperPrefab;
    public GameObject scrollViewObject;
    public GameObject scrollViewContent;
    public GameObject emojiSpawner;
}
