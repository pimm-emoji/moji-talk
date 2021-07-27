using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The IngamePlayScene
*/
public class IngamePlayScene : MonoBehaviour
{    
    public GameObject MessageWrapperPrefab;
    List<Level> flow;

    void Start()
    {
        IngameDataManager.instance.LoadLevel("debug");
        flow = IngameDataManager.instance.GetLevelFlow();
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
}
