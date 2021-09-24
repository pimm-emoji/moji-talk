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
	public bool spawnswitch = false;
	bool duplicate = false;
	public int bpm = 128;
	public GameObject sceneManager;
	IngameSceneManager sceneManagerComponent;

	void Start () {
		sceneManagerComponent = sceneManager.GetComponent<IngameSceneManager>();
		generateConfig = IngameDataManager.instance.flow.flow[sceneManagerComponent.flowIndex[0]].generates;
	}

	void Update()
    {
		if(!spawnswitch)
		{
			StopCoroutine(SpawnEmojis());
			duplicate = false;
        }

		else if(spawnswitch)
		{
			if (!duplicate)
			{
				LoadGenerateConfig();
				StartCoroutine(SpawnEmojis());
				duplicate = true;
			}

		}

    }


	void LoadGenerateConfig() { LoadGenerateConfig(IngameDataManager.instance.flow.flow[sceneManagerComponent.flowIndex[0]].generates);  /* start에서 가져온 ingamemanager에서 generate 값을 받아 저장한다.*/ }
	void LoadGenerateConfig(EmojiGenerations Generations) { generateConfig = Generations; }


	void mode0()
    {
		int spawnIndex = Random.Range(0, 10);
		Transform spawnPoint = spawnPoints[spawnIndex];

		GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);

		LoadGenerateConfig();



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
			LoadGenerateConfig();
			int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
			spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];

			spawnedEmoji.transform.SetParent(this.transform);
			Destroy(spawnedEmoji, 5f);
		}

    }

	void mode2()
	{
		int spawnIndex = Random.Range(0, 10);
		int spawnIndex2 = Random.Range(0, 10);
		while (spawnIndex == spawnIndex2)
		{
			spawnIndex2 = Random.Range(0, 10);
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
					spawnedEmoji.transform.SetParent(this.transform);
					Destroy(spawnedEmoji, 5f);
				}

				else if (ratio == 1)
				{
					int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
					spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];
					spawnedEmoji.transform.SetParent(this.transform);
					Destroy(spawnedEmoji, 5f);
				}
			}
			else if (i == 1)
			{
				int ratio = Random.Range(0, 2);

				if (ratio == 0)
				{
					int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
					spawnedEmoji2.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];
					spawnedEmoji2.transform.SetParent(this.transform);
					Destroy(spawnedEmoji2, 5f);
				}

				else if (ratio == 1)
				{
					int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
					spawnedEmoji2.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];
					spawnedEmoji2.transform.SetParent(this.transform);
					Destroy(spawnedEmoji2, 5f);

				}
			}
		}
	}


	void mode3()
	{
		int spawnIndex = Random.Range(0, 4);
		int spawnIndex2 = Random.Range(0, 4);

		while (spawnIndex == spawnIndex2)
		{
			spawnIndex2 = Random.Range(0, 10);
		}

		int spawnIndex3 = Random.Range(10, 12);

		Transform spawnPoint = spawnPoints[spawnIndex];
		Transform spawnPoint2 = spawnPoints[spawnIndex2];
		Transform spawnPoint3 = spawnPoints[spawnIndex3];


		GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);
		GameObject spawnedEmoji2 = Instantiate(emojiPrefab, spawnPoint2.position, spawnPoint2.rotation);
		GameObject spawnedEmoji3 = Instantiate(emojiPrefab, spawnPoint3.position, spawnPoint3.rotation);

		LoadGenerateConfig();

		for (int i = 0; i < 3; i++)
		{
			if (i == 0)
			{
				int ratio = Random.Range(0, 2);

				if (ratio == 0)
				{
					int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
					spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];
					spawnedEmoji.transform.SetParent(this.transform);
					Destroy(spawnedEmoji, 5f);
				}

				else if (ratio == 1)
				{
					int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
					spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];
					spawnedEmoji.transform.SetParent(this.transform);
					Destroy(spawnedEmoji, 5f);
				}
			}
			else if (i == 1)
			{
				int ratio = Random.Range(0, 2);

				if (ratio == 0)
				{
					int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
					spawnedEmoji2.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];
					spawnedEmoji2.transform.SetParent(this.transform);
					Destroy(spawnedEmoji2, 5f);
				}

				else if (ratio == 1)
				{
					int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
					spawnedEmoji2.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];
					spawnedEmoji2.transform.SetParent(this.transform);
					Destroy(spawnedEmoji2, 5f);

				}
			}

			else if (i == 2)
			{
				int ratio = Random.Range(0, 2);

				if (ratio == 0)
				{
					int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
					spawnedEmoji3.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[mojirange];
					spawnedEmoji3.transform.SetParent(this.transform);
					Destroy(spawnedEmoji3, 5f);
				}

				else if (ratio == 1)
				{
					int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
					spawnedEmoji3.GetComponent<Emojis>().emoji = generateConfig.negativeEmojis[mojirange];
					spawnedEmoji3.transform.SetParent(this.transform);
					Destroy(spawnedEmoji3, 5f);

				}
			}



		}
	}



	IEnumerator SpawnEmojis()
	{
		while (spawnswitch)
		{
			yield return new WaitForSeconds(60f / bpm);

			int mode = Random.Range(0, 7);
			if (mode <=3)
			{
				mode0();
			}
			else if (mode == 4)
			{
				mode1();
			}
			else if (mode == 5)
			{
				mode2();
			}
			else if( mode == 6)
            {
				mode3();
            }
		}
	}
}


