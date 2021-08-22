using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EmojiSpawner : MonoBehaviour {

	public GameObject emojiPrefab; 
	public Transform[] spawnPoints;
	public Emoji emojidata;
	public EmojiGenerations generateConfig;

	public int bpm = 128;

	[ContextMenu("LoadDemoGenData")]
	

	void Start () {
		IngameDataManager.instance.LoadLevel("1");  // ingamedatamanger에서 "1" 레벨을 로드하고

		StartCoroutine(SpawnEmojis()); // 생성 후 delay 초마다 멈추기
	
	}


	void LoadDemoData()  //generateConfig 값을 인게임 매니져에서 가져온다.
	{
		//예전 코드-- generateconfig 값을 인게임 매니져에서 가져오면서 기존 코드 주석처리 해놓음.
	/*
		generateConfig = PresetController.LoadGenData(
			PresetController.LoadJsonToObject(
				Path.Combine(Configs.PresetPath, "demo", "emojiGenerations.json")
	
			)
		);
	*/	


		generateConfig = IngameDataManager.instance.flow[GameManager.instance.nowFlowIndex].generates;  // start에서 가져온 ingamemanager에서 generate 값을 받아 저장한다.
	}

	// 그런데 Object reference not set to an instance of an object 오류가 뜸





	// 긍정, 부정 이모지 중 선택
	public int Selmojiconfig(int ratio)
    {
		if (ratio <=0)
		{
			int mojirange = Random.Range(0, generateConfig.positiveEmojis.Count);
			return mojirange;
			
		}

		else if (ratio>0 && ratio <2)
		{
			int mojirange = Random.Range(0, generateConfig.negativeEmojis.Count);
			return mojirange;
	
		}
        else
        {
			return 0;
        }
	}


	//note가 나오는 4가지 모드
	IEnumerator NoteMode(int notemode)
    {
		if(notemode == 0)
        {
			for(int i = 0; i < 5; i++)
            {
				yield return new WaitForSeconds(60f / bpm);
				int spawnIndex = Random.Range(0, spawnPoints.Length);
				Transform spawnPoint = spawnPoints[spawnIndex];

				GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);

				LoadDemoData();

				int ratio = Random.Range(0, 2);
				spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[Selmojiconfig(ratio)];

				spawnedEmoji.transform.SetParent(this.transform);
				Destroy(spawnedEmoji, 5f);
			}
		}

		else if(notemode == 1)
        {
			yield return new WaitForSeconds(60f / bpm);
			for(int i=0; i< 4; i++)
            {
				Transform spawnPoint = spawnPoints[i];
				GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);
				LoadDemoData();

				int ratio = 0;
				spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[Selmojiconfig(ratio)];

				spawnedEmoji.transform.SetParent(this.transform);
				Destroy(spawnedEmoji, 5f);
			}
        }

		else if(notemode == 2)
        {
			yield return new WaitForSeconds(60f / bpm);
			for (int i = 4; i > 0; i--)
			{
				Transform spawnPoint = spawnPoints[i];
				GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);
				LoadDemoData();

				int ratio = 0;
				spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[Selmojiconfig(ratio)];

				spawnedEmoji.transform.SetParent(this.transform);
				Destroy(spawnedEmoji, 5f);
			}

		}

		else if(notemode ==3)
        {
			for (int i = 0; i < 5; i++)
			{
				yield return new WaitForSeconds(60f / bpm);
				int spawnIndex = Random.Range(4, spawnPoints.Length);
				Transform spawnPoint = spawnPoints[spawnIndex];

				GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);

				LoadDemoData();

				int ratio = Random.Range(0, 2);
				spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[Selmojiconfig(ratio)];

				spawnedEmoji.transform.SetParent(this.transform);
				Destroy(spawnedEmoji, 5f);
			}
		}

		else if(notemode == 4)
        {
			yield return new WaitForSeconds(60f / bpm);
			for (int i = 4; i > 0; i--)
			{
				Transform spawnPoint = spawnPoints[i];
				GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);
				LoadDemoData();

				int ratio = Random.Range(0, 2);
				spawnedEmoji.GetComponent<Emojis>().emoji = generateConfig.positiveEmojis[Selmojiconfig(ratio)];

				spawnedEmoji.transform.SetParent(this.transform);
				Destroy(spawnedEmoji, 5f);
			}
		}

    }


	// 위의 모드 4가지 중 랜덤으로 생성
	IEnumerator SpawnEmojis ()
	{
        while (true)
        {
			int notemode = Random.Range(0, 5);
			NoteMode(notemode);
		}
	}
	
}

