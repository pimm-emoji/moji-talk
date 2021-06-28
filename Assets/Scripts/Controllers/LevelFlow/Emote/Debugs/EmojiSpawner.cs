using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiSpawner : MonoBehaviour {

	public GameObject emojiPrefab;
	public Transform[] spawnPoints;

	public float minDelay = 0.5f;
	public float maxDelay = 2f;


	void Start () {
		StartCoroutine(SpawnEmojis()); // 생성 후 delay 초마다 멈추기
	}

	IEnumerator SpawnEmojis ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);  // 스폰포인트 랜덤으로 뽑기
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation); //이모지 생성
			Destroy(spawnedEmoji, 5f); //5f 뒤 파괴
		}
	}
	
}
