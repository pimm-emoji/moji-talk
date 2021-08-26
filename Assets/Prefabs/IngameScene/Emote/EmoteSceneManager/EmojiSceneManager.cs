using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiSceneManager : MonoBehaviour
{
    EmojiSpawner emojispawner;
    float ftime;
    float flimittime;
    float previousscore;
    float nowscore;
    float earnscore;
    float dividescore1;
    float dividescore2;
    float dividescore3;
    List<Level> flow;

    void Start()
    {
        emojispawner = GameObject.Find("EmojiNote").GetComponent<EmojiSpawner>();
        IngameDataManager.instance.LoadLevel("first");
        flow = IngameDataManager.instance.GetLevelFlow();
        previousscore = 0f;
        StartCoroutine(ProcessingFlows());

    }

     IEnumerator ProcessingFlows()
    {
        int i = 1; // index
        flimittime = flow[i].duration / 1000;
        Debug.Log("flimi = " + flimittime);

        dividescore1 = flow[i].branch.divider[0];
        dividescore2 = flow[i].branch.divider[1];
        dividescore3 = flow[i].branch.divider[2];

        emojispawner.spawnswitch = true;
        yield return new WaitForSeconds(flow[i].duration / 1000);
        emojispawner.spawnswitch = false;
        nowscore = GameManager.instance.GetScore();
        earnscore = nowscore - previousscore;

        if (earnscore <= dividescore1)
        {
            i = flow[i].branch.index[0];
        }

        else if (earnscore <= dividescore2 && earnscore > dividescore1)
        {
            i = flow[i].branch.index[1];
        }

        else if (earnscore <= dividescore3 && earnscore > dividescore2)
        {
            i = flow[i].branch.index[2];
        }

        else if (earnscore > dividescore3)
        {
            i = flow[i].branch.index[3];
        }

        // Processing chatting Scene
        //chatting.loadchat()

    }
}



     