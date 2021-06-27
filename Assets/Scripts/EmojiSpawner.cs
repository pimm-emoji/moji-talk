using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiSpawner : MonoBehaviour {

	public GameObject emojiPrefab;
	public Transform[] spawnPoints;

	public float minDelay = 0.5f;
	public float maxDelay = 2f;


	void Start () {
		StartCoroutine(SpawnEmojis()); // ���� �� delay �ʸ��� ���߱�
	}

	IEnumerator SpawnEmojis ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);  // ��������Ʈ �������� �̱�
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedEmoji = Instantiate(emojiPrefab, spawnPoint.position, spawnPoint.rotation); //�̸��� ����
			Destroy(spawnedEmoji, 5f); //5f �� �ı�
		}
	}
	
}
