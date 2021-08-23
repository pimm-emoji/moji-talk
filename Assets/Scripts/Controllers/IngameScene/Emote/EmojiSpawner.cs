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

	IEnumerator SpawnEmojis()
	{
		while (true)
		{
			yield return new WaitForSeconds(60f / bpm);

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
	}
	
}

