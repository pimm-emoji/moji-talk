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


		generateConfig = IngameDataManager.instance.flow[GameManager.instance.nowFlowIndex].generates;
	}

	void Start () {
		StartCoroutine(SpawnEmojis()); // 생성 후 delay 초마다 멈추기
	
	}

	IEnumerator SpawnEmojis ()
	{
        while (true)
        {
			yield return new WaitForSeconds(60f/bpm);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation);

			LoadDemoData();

			

			int ratio = Random.Range(0, 2);

			if(ratio == 0)
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

		
		
	}
	
}

