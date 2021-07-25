using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; //emojislicedprefab , startforce 변수
	public float startForce = 15f;
	
	public int isCut = 0; 
	bool dupli = false;

	Rigidbody2D rb;
	RectTransform rect;   

	void Start ()  
	{
		rb = GetComponent<Rigidbody2D>();             //rigidbody에 시작 힘을 가함
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

		rect = GetComponent<RectTransform>();  //현재 이모지의 Transform 가져옴

	}

	void OnTriggerEnter2D (Collider2D col)  //충돌 시
	{

		if (dupli == false)   // 중복으로 잘림을 방지
		{
			if (col.tag == "Blade")  //Blade 태그를 가진 오브젝트와 충돌 시
			{

				Vector3 direction = (col.transform.position - transform.position).normalized;
				Quaternion rotation = (Quaternion.LookRotation(forward : Vector3.forward, upwards : direction)); //

			
			

				GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  // 잘린 과일 오브젝트 생성

				
				Destroy(slicedEmoji, 3f);

				rect.localScale = new Vector3(0, 0, 0);  // 크기를 0으로 만들어 버림 --- 바로 파괴하지 않는 이유는 판정을 위함.
				Destroy(gameObject, 2f);
				soundManager.instance.PlaySound();  //잘리는 효과음
				isCut = 1;    // 다른 스크립트에서 쓸 거임.
				dupli = true;

			}

			else if(col.tag == "Misszone")  // MissZone tag를 가진 오브젝트와 충돌 시
			{ 
				rect.localScale = new Vector3(0, 0, 0);
				Destroy(gameObject, 2f);
				isCut = 2;
				dupli = true;
			}
		}
	}

}
