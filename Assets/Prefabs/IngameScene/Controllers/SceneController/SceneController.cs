﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    EmojiSpawner emojispawner;
    float BranchScore;
    int dividercount;
    bool dupl;
    public static SceneController instance = null;

    List<Level> flow;

    public GameObject MessageWrapperPrefab;
    public GameObject ScrollViewObject;
    public GameObject ScrollViewContent;
    float[] offset = { ChattingConfig.VerticalLayoutGroupOffset[0], ChattingConfig.VerticalLayoutGroupOffset[1], ChattingConfig.VerticalLayoutGroupOffset[2], ChattingConfig.VerticalLayoutGroupOffset[3] };
    float Spacing = ChattingConfig.VerticalLayoutGroupOffset[4];
    public int i = 0; // index


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
    }
    void Start()
    {
        StartMessageSpawn();
    }

    public void StartEmojiSpawn()
    {
        emojispawner = GameObject.Find("EmojiNote").GetComponent<EmojiSpawner>();
        IngameDataManager.instance.LoadLevel("first");
        flow = IngameDataManager.instance.GetLevelFlow();
        StartCoroutine(ProcessingEmojiFlows());


        dupl = false;
    }

    public void ResetEmojiSpawn()
    {
        emojispawner.spawnswitch = false;
        GameManager.instance.InitScore();
        GameManager.instance.InitBranchScore();
    }


    public IEnumerator ProcessingEmojiFlows()
    {
     
        emojispawner.spawnswitch = true;
        yield return new WaitForSeconds(flow[i].duration / 1000);
        emojispawner.spawnswitch = false;
        BranchScore = GameManager.instance.GetBranchScore();

        dividercount = flow[i].branch.divider.Count;

        for (int a = 0; a < dividercount; a++)
        {

            if (dupl == false)
            {
                if (BranchScore <= flow[i].branch.divider[a])
                {
                    i = flow[i].branch.index[a];
                    dupl = true;
                }
            }
        }
        GameManager.instance.InitBranchScore();
        StartMessageSpawn();


    }

    public void StartMessageSpawn()
    {
        IngameDataManager.instance.LoadLevel("first");
        flow = IngameDataManager.instance.GetLevelFlow();
        VerticalLayoutGroup VerticalLayoutGroup = ScrollViewContent.GetComponent<VerticalLayoutGroup>();
        RectTransform rectTransform = ScrollViewContent.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, offset[3]);
        VerticalLayoutGroup.spacing = Spacing * 2;
        VerticalLayoutGroup.padding = new RectOffset((int)offset[0], (int)offset[1], (int)offset[2], (int)offset[3]);
        StartCoroutine(ProcessingMessageFlows());
    }

    IEnumerator ProcessingMessageFlows()
    {
        bool Flag = true;
        int i = 0; // index
        while (Flag)
        {
            if (flow[i].type == "chatting")
            {
                foreach (var message in flow[i].chats)
                {
                    // Processing Message
                    print(message.content);
                    GameObject newObject = Instantiate(MessageWrapperPrefab) as GameObject;
                    newObject.transform.SetParent(GameObject.Find("Content").transform);
                    newObject.GetComponent<ChattingWrapperController>().init(message.author, message.content, message.author != "player" ? 0 : 1);
                    AddScrollViewContentHeight(newObject);
                    MoveToBottom();
                    /*var newObjectRectSize = newObject.GetComponent<ChattingWrapperController>().GetSize();
                    AddScrollViewContentHeight(newObjectRectSize.y);
                    newObject.GetComponent<RectTransform>().sizeDelta = newObjectRectSize;*/

                    yield return new WaitForSeconds(message.delay / 1000);
                }
                i = flow[i].branch.index[0];
            }
            else if (flow[i].type == "emote")
            {
                // Processing Emote Scene
                StartEmojiSpawn();
                ResetEmojiSpawn();
            }
            else if (flow[i].type == "end")
            {
                Flag = false;

            }
        }
    }

    void AddScrollViewContentHeight(GameObject GameObject)
    {
        Vector2 RectSize = ScrollViewContent.GetComponent<RectTransform>().sizeDelta;
        float height = GameObject.GetComponent<RectTransform>().sizeDelta.y;
        ScrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(RectSize.x, RectSize.y + height + Spacing);
    }
    void MoveToTop() { MoveScroll(1); }
    void MoveToBottom() { MoveScroll(0); }
    void MoveScroll(float value) { ScrollViewObject.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, value); }

}
