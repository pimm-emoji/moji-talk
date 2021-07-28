using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//추가해야 할 것 : 1. Assets/Presets/demo/emojiGenerations.json 파일 읽어들이기
//2. MojiCircle의 sprite render에 접근하기
//3. 해당 sprite 변경하기
public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; // 잘렸을 때의 prefab과 던지는 힘 설정.
	public float startForce = 15f;

	public EmojiGenerations generateConfig; //json에 담긴 emoji 정보 가져옴
	public Emoji emoji;

	public SpriteRenderer renderer; //sprite renderer 접근
	public Sprite spr;

	public int isCut = 0;  // 잘렸는지 여부 판정을 위한 변수
	bool dupli = false;

	Rigidbody2D rb;
	RectTransform rect;


	
	[ContextMenu("LoadDemoGenData")]
	void LoadDemoData()
	{
		generateConfig = PresetController.LoadJsonToObject(
			Path.Combine(Configs.PresetPath, "demo", "emojiGenerations.json")
			).ToObject<EmojiGenerations>();

		//새 방법
		generateConfig = PresetController.LoadGenData(
			PresetController.LoadJsonToObject(
				Path.Combine(Configs.PresetPath, "demo", "emojiGenerations.json")
			)
		);
	}

	[ContextMenu("LoadDemoEmojiData")]
	void LoadDemoEmojiData()
	{ 
		emoji = PresetController.LoadJsonToObject(Path.Combine(Configs.PresetPath, "demo", "emoji.json")).ToObject<Emoji>();
	}



	void Start ()  
	{
		//rigidbody에 시작 힘을 가함
		rb = GetComponent<Rigidbody2D>();             
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

		//현재 이모지의 Transform 가져옴
		rect = GetComponent<RectTransform>();

		LoadDemoData();
		LoadDemoEmojiData();


		//자식 오브젝트의 컴포넌트 접근, json 이미지 경로 스프라이트 로딩
		renderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
		spr = Resources.Load<Sprite>(emoji.asset);

		renderer.sprite = spr;


	}


	//충돌 시 처리하는 코드
	void OnTriggerEnter2D (Collider2D col)  
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

				// 제대로 넘어오는지 테스트 하기 위한 용도임 !!!!! 나중에 지울것!!!!
				Debug.Log(emoji.ondestroy); 
				Debug.Log(emoji.asset);
				Debug.Log(emoji.id);


				// 잘려진 이모지 프리팹 생성
				GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  

				// 잘려진 이모지 파괴
				Destroy(slicedEmoji, 3f);


				//원래 이모지의 크기를 0으로 만들어 버림 --- 바로 파괴하지 않는 이유는 판정을 위함.
				rect.localScale = new Vector3(0, 0, 0);  
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
