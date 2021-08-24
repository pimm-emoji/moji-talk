using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EmojiSpawner : MonoBehaviour
{

	public GameObject emojiPrefab;
	public Transform[] spawnPoints;
	public Emoji emojidata;
	public EmojiGenerations generateConfig;

	public int bpm = 128;

	[ContextMenu("LoadDemoGenData")]
	

	void Start () {
		IngameDataManager.instance.LoadLevel("first");  // ingamedatamanger에서 "first" 레벨을 로드하고
		Debug.Log("Eflow"   + GameManager.instance.nowFlowIndex);
		StartCoroutine(SpawnEmojis()); // 생성 후 delay 초마다 멈추기
		generateConfig = IngameDataManager.instance.flow[1].generates;
	}


	void LoadDemoData()  //generateConfig 값을 인게임 매니져에서 가져온다.
	{
		generateConfig = IngameDataManager.instance.flow[1].generates;  // start에서 가져온 ingamemanager에서 generate 값을 받아 저장한다.
	}






	void mode0()
    {
		int spawnIndex = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[spawnIndex];

		GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);

		LoadDemoData();



		int ratio = Random.Range(0, 2);

		if (ratio == 0)
		{
			int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
			spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];
		}

		else if (ratio == 1)
		{
			int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
			spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];
		}

		spawnedEmoji.transform.SetParent(this.transform);
		Destroy(spawnedEmoji, 5f);
    }

	
	void mode1()
    {
		for(int i = 0; i < 4; i++)
        {
			int spawnIndex = i;
			Transform spawnPoint = spawnPoints[spawnIndex];
			GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);
			LoadDemoData();
			int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
			spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];

			spawnedEmoji.transform.SetParent(this.transform);
			Destroy(spawnedEmoji, 5f);
		}

    }

	void mode2()
	{
		int spawnIndex = Random.Range(0, spawnPoints.Length);
		int spawnIndex2 = Random.Range(0, spawnPoints.Length);
		while (spawnIndex == spawnIndex2)
		{
			spawnIndex2 = Random.Range(0, spawnPoints.Length);
		}
		Transform spawnPoint = spawnPoints[spawnIndex];
		Transform spawnPoint2 = spawnPoints[spawnIndex2];
		GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);
		GameObject spawnedEmoji2 = Instantiate(emojiPrefab, spawnPoint2.position, spawnPoint2.rotation);

		for (int i = 0; i < 2; i++)
		{
			if (i == 0)
			{
				int ratio = Random.Range(0, 2);

				if (ratio == 0)
				{
					int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
					spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];
				}

				else if (ratio == 1)
				{
					int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
					spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];
				}
			}
			else if (i == 1)
			{
				int ratio = Random.Range(0, 2);

				if (ratio == 0)
				{
					int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
					spawnedEmoji2.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];
				}

				else if (ratio == 1)
				{
					int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
					spawnedEmoji2.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];

				}
			}
		}

		spawnedEmoji.transform.SetParent(this.transform);
		spawnedEmoji2.transform.SetParent(this.transform);
		Destroy(spawnedEmoji, 5f);
		Destroy(spawnedEmoji2, 5f);


	}



	IEnumerator SpawnEmojis()
	{
		while (true)
		{
			yield return new WaitForSeconds(60f / bpm);

			int mode = Random.Range(0, 3);
			if (mode == 0)
			{
				mode0();
			}
			else if (mode == 1)
			{
				mode1();
			}
			else if (mode == 2)
			{
				mode2();
			}
		}
	}
}


