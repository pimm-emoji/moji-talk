using System.Collections;
using UnityEngine;

public class EmojiGenerator : MonoBehaviour
{
    public EmojiGenerations emojiGenrations;
    public EmojiBridge emojiBridge;
    void Start() 
    {
    }
    void Update()
    {}
    public void TriggerStart()
    {
        emojiGenerations = IngameDataManager.instance.flow[GameManager.instance.flowIndex].generates;
    }

    IEnumerator GenerateEmojis()
    {
        while (true)
        {
            yield return new WaitForSeconds(
                Random.Range(
                    EmojiGeneratingConfig.GenCycle - EmojiGeneratingConfig.GenCycleOffset,
                    EmojiGeneratingConfig.GenCycle + EmojiGeneratingConfig.GenCycleOffset
                )
            );

            int generates = GetRandomResult(EmojiGeneratingConfig.GenMaximumEmojisRatio);
            for (int i = 0; i < generates; i++)
            {
                if (GetRandomResult(emojiGenrations.ratio) == 0)
                {}
                InstantiateEmojiBridge(_EMOJI_, GeneratePosition);
            }
        }
    }

    GameObject InstantiateEmojiBridge(Emoji Emoji, Vector2 GeneratePosition)
    {
        GameObject newObject = Instantiate(emojiBridge, GeneratePosition, new Quaternion()) as GameObject;
        newObject.GetComponent<EmojiBridge>().Init(Emoji);
        return newObject;
    }

    Vector3 GeneratePosition()
    {
        // Todo: Position
        float select = Random.Range(Screen.height * -1, Screen.width + Screen.height);
        if (select < 0)
        {
            return new Vector3(0, select, 0);
        }
        else if (select < Screen.width) return new Vector3(select, 0, 0);
        else return new Vector3(0, select - Screen.width, 0);
    }

    int GetRandomResult(float[] ratio)
    {
        float random = Random.range(0, ratio.Sum());
        float cnt = 0;
        for (int i = 0; i < ratio.Length; i++)
        {
            cnt += ratio[i];
            if (random < cnt) return i;
        }
        return 0;
    }
}
