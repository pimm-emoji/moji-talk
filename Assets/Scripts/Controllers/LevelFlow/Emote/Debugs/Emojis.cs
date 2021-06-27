using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; //emojislicedprefab , startforce 변수
	public float startForce = 15f;

	Rigidbody2D rb;

	void Start ()  //rigidbody에 시작 힘을 가함
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D col)  //Blade 태그를 가진 오브젝트와 충돌 시
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction); //

			GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  // 잘린 과일 오브젝트 생성
			Destroy(slicedEmoji, 3f);
			Destroy(gameObject);
		}
	}

}
