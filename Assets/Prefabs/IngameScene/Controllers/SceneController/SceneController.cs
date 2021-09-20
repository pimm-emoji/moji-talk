using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        IngameDataManager.instance.LoadLevelEntire(!string.IsNullOrEmpty(GameManager.instance.nowLevelID) ? GameManager.instance.nowLevelID : "first");
        flow = IngameDataManager.instance.GetLevelFlow();
    }

    void Update()
    {
        FlowHandler();
    }

    public int[] flowIndex = {0, 0};
    public float previousFlowElapsed = 0;
    public bool triggerFlow = true;
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
            }
            else if (flow.flow[flowIndex[0]].type == "emote")
            {
                // Start Emoji Spawner Handler
                StartEmojiSpawner();
            }
            else if (flow.flow[flowIndex[0]].type == "end")
            {
                // Trigger Ending
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
}

[System.Serializable]
public class IngameSceneGameObjects
{
    public GameObject chattingWrapperPrefab;
    public GameObject scrollViewObject;
    public GameObject scrollViewContent;
    public GameObject emojiSpawner;
}
