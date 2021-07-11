using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngamePlayScene : MonoBehaviour
{    
    Flow Flow;

    void Start()
    {
        GameManager.instance.SetLevel("debug");
        Flow = GameManager.instance.GetLevelFlow();
        StartCoroutine(ProcessingFlows());
    }

    IEnumerator ProcessingFlows()
    {
        bool Flag = true;
        int i = 0; // index
        while (Flag)
        {
            if (Flow.flow[i].type == "chatting")
            {
                foreach(var message in Flow.flow[i].chats)
                {
                    // Processing Message
                    print(message.content);

                    yield return new WaitForSeconds(message.delay / 1000);
                }
                i = Flow.flow[i].branch.index[0];
            }
            else if (Flow.flow[i].type == "emote")
            {
                // Processing Emote Scene

                yield return new WaitForSeconds(Flow.flow[i].duration / 1000);
            }
            else if (Flow.flow[i].type == "end")
            {
                Flag = false;
            }
        }
    }
}
