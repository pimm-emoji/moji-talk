using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; // 잘렸을 때의 prefab과 던지는 힘 설정.
	public float startForce = 15f;

	public EmojiGenerations generateConfig; //json에 담긴 emoji 정보 가져옴
	public Emoji emoji;
	public Emoji newemoji;

	public SpriteRenderer renderer; //sprite renderer 접근
	public Sprite spr;

	public int isCut = 0;  // 잘렸는지 여부 판정을 위한 변수
	bool dupli = false;

	Vector3 MousePosition;
	Vector3 CenterPosition;
	Camera Camera;
	public float distance;

	Rigidbody2D rb;
	RectTransform rect;



	



	void Start ()  
	{
		//rigidbody에 시작 힘을 가함
		rb = GetComponent<Rigidbody2D>();             
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

		//현재 이모지의 Transform 가져옴
		rect = GetComponent<RectTransform>();


		//자식 오브젝트의 컴포넌트 접근, json 이미지 경로 스프라이트 로딩
		renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
		newemoji = Emoji.LoadEmoji(emoji.id);
		renderer.sprite = newemoji.sprite;

		// distance 구하기
		Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		distance = 500f;



	}


	//충돌 시 처리하는 코드
	void OnTriggerExit2D (Collider2D col)  
	{
		// 중복으로 잘림을 방지
		if (dupli == false)   
		{
			//Blade 태그를 가진 오브젝트와 충돌 시
			if (col.tag == "Blade")  
			{
				// 잘린 방향 설정
				Vector3 direction = (col.transform.position - transform.position).normalized;
				Quaternion rotation = (Quaternion.LookRotation(forward : Vector3.forward, upwards : direction)); //



				// 잘려진 이모지 프리팹 생성
				GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  

				// 잘려진 이모지 파괴
				Destroy(slicedEmoji, 3f);


				
				// 스프라이트 비활성화(판정을 위해 바로 파괴하지는 않음)
				renderer.enabled = false;
				rect.localScale = new Vector3(0, 0, 0);

				Destroy(gameObject, 2f);
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

	// 중심과 이모지 사이 거리 측정
	void OnTriggerStay2D(Collider2D col)
    {
		if (col.tag == "Blade")
        {
			float distanceupd;
			CenterPosition = rect.transform.position;
			MousePosition = Input.mousePosition;

			
			
			MousePosition = Camera.ScreenToWorldPoint(MousePosition);
			//CenterPosition = RectTransformUtility.WorldToScreenPoint(Camera, CenterPosition);
			distanceupd = Vector3.Distance(MousePosition, CenterPosition);
			if(distanceupd < distance)
            {
				distance = distanceupd;
            }
		}
	}

	

}
