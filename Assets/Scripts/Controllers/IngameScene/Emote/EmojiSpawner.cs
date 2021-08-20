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
	void LoadDemoData()
	{
		//새 방법
		generateConfig = PresetController.LoadGenData(
			PresetController.LoadJsonToObject(
				Path.Combine(Configs.PresetPath, "demo", "emojiGenerations.json")
			)
		);
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

			// if 난수 구현 결과 positive라면

			// spawnedEmoji.GetComponent<Emojis>().emoji = (positive 데이터);

			// positive 데이터 가지고 오는 방법? generateConfig[1] 이런 식으로 참조하면 되나? 아니면 generateConfig.positiveEmojis[1] 이런식으로 참조해야 하나?
			// 이 때 여러 .length 에서 랜덤으로 하나 뽑기.



			spawnedEmoji.transform.SetParent(this.transform);
			Destroy(spawnedEmoji, 5f);
		}

		
		
	}
	
}

