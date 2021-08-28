using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiSceneManager : MonoBehaviour
{
    EmojiSpawner emojispawner;
    float BranchScore;
    float dividescore1;
    float dividescore2;
    float dividescore3;
    int dividercount;
    List<Level> flow;
    bool dupl;

    void Start()
    {
        StartScene();
    }

    public void StartScene()
    {
        emojispawner = GameObject.Find("EmojiNote").GetComponent<EmojiSpawner>();
        IngameDataManager.instance.LoadLevel("first");
        flow = IngameDataManager.instance.GetLevelFlow();
        StartCoroutine(ProcessingFlows());
<<<<<<< Updated upstream
=======

        dupl = false;
    }

    public void ResetScene()
    {
        emojispawner.spawnswitch = false;
        GameManager.instance.InitScore();
        GameManager.instance.InitBranchScore();

>>>>>>> Stashed changes
    }

    /*
        점수가 나오게 되면
        divider.Add(100);
        for(int i; i < divider.count)
        {
            if (score < divider[i]) 
            {
                index[i] 분기로 보냄
            }
        }
    */
    IEnumerator ProcessingFlows()
    {
        int i = 1; // index


        emojispawner.spawnswitch = true;
        yield return new WaitForSeconds(flow[i].duration / 1000);
        emojispawner.spawnswitch = false;
        BranchScore = GameManager.instance.GetBranchScore();

        dividercount = flow[i].branch.divider.Length;

        for (int a = 0; a < dividercount; a++)
        {

            if (dupl = false)
            {
                if (BranchScore <= flow[i].branch.divider[a])
                {
                    i = flow[i].branch.index[a];
                    dupl = true;
                }
            }
        }
        GameManager.instance.InitBranchScore();


        // Processing chatting Scene
        //chatting.loadchat()

    }
}



     