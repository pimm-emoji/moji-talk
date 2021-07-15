using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiSpawner : MonoBehaviour {

	public GameObject emojiPrefab1; 
	public GameObject emojiPrefab2;
	public Transform[] spawnPoints;

	public int bpm = 128;



	void Start () {
		StartCoroutine(SpawnEmojis()); // ���� �� delay �ʸ��� ���߱�
	
	}

	IEnumerator SpawnEmojis ()
	{
        while (true)
        {
			yield return new WaitForSeconds(60f/bpm);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedEmoji = Instantiate(emojiPrefab1, spawnPoint.position, spawnPoint.rotation);
			spawnedEmoji.transform.SetParent(this.transform);
			Destroy(spawnedEmoji, 5f);
		}

		
		
	}
	
}

