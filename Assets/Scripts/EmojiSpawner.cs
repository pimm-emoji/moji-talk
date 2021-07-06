using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiSpawner : MonoBehaviour {

	public GameObject emojiPrefab;
	public Transform[] spawnPoints;

	public float minDelay = 0.5f;
	public float maxDelay = 3f;


	void Start () {
		StartCoroutine(SpawnEmojis()); // 생성 후 delay 초마다 멈추기
	}

	IEnumerator SpawnEmojis ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int mode = Random.Range(1, 3);
			if (mode == 1)
            {
				Transform spawnPoint1 = spawnPoints[0];
				Transform spawnPoint2 = spawnPoints[1];
				Transform spawnPoint3 = spawnPoints[2];

				GameObject spawnedEmoji1 = Instantiate(emojiPrefab, spawnPoint1.position, spawnPoint1.rotation);
				GameObject spawnedEmoji2 = Instantiate(emojiPrefab, spawnPoint2.position, spawnPoint2.rotation);
				GameObject spawnedEmoji3 = Instantiate(emojiPrefab, spawnPoint3.position, spawnPoint3.rotation);

				Destroy(spawnedEmoji1, 5f);
				Destroy(spawnedEmoji2, 5f);
				Destroy(spawnedEmoji3, 5f);

				yield return new WaitForSeconds(2f);

			}
			
	
			else if(mode == 2)
            {
				int spawnIndex = Random.Range(0, spawnPoints.Length);  // 스폰포인트 랜덤으로 뽑기
				Transform spawnPoint = spawnPoints[spawnIndex];

				GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation); //이모지 생성
				Destroy(spawnedEmoji, 5f); //5f 뒤 파괴
			}




		
		}
	}
	
}
