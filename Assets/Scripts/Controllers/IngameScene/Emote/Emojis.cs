using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�߰��ؾ� �� �� : 1. Assets/Presets/demo/emojiGenerations.json ���� �о���̱�
//2. MojiCircle�� sprite render�� �����ϱ�
//3. �ش� sprite �����ϱ�
public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; // �߷��� ���� prefab�� ������ �� ����.
	public float startForce = 15f;

	public EmojiGenerations generateConfig; //json�� ��� emoji ���� ������
	public Emoji emoji;

	public SpriteRenderer renderer; //sprite renderer ����
	public Sprite spr;

	public int isCut = 0;  // �߷ȴ��� ���� ������ ���� ����
	bool dupli = false;

	Rigidbody2D rb;
	RectTransform rect;


	
	[ContextMenu("LoadDemoGenData")]
	void LoadDemoData()
	{
		generateConfig = PresetController.LoadJsonToObject(
			Path.Combine(Configs.PresetPath, "demo", "emojiGenerations.json")
			).ToObject<EmojiGenerations>();

		//�� ���
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
		//rigidbody�� ���� ���� ����
		rb = GetComponent<Rigidbody2D>();             
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

		//���� �̸����� Transform ������
		rect = GetComponent<RectTransform>();

		LoadDemoData();
		LoadDemoEmojiData();


		//�ڽ� ������Ʈ�� ������Ʈ ����, json �̹��� ��� ��������Ʈ �ε�
		renderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
		spr = Resources.Load<Sprite>(emoji.asset);

		renderer.sprite = spr;


	}


	//�浹 �� ó���ϴ� �ڵ�
	void OnTriggerEnter2D (Collider2D col)  
	{

		// �ߺ����� �߸��� ����
		if (dupli == false)   
		{
			//Blade �±׸� ���� ������Ʈ�� �浹 ��
			if (col.tag == "Blade")  
			{
				// �߸� ���� ����
				Vector3 direction = (col.transform.position - transform.position).normalized;
				Quaternion rotation = (Quaternion.LookRotation(forward : Vector3.forward, upwards : direction)); //

				// ����� �Ѿ������ �׽�Ʈ �ϱ� ���� �뵵�� !!!!! ���߿� �����!!!!
				Debug.Log(emoji.ondestroy); 
				Debug.Log(emoji.asset);
				Debug.Log(emoji.id);


				// �߷��� �̸��� ������ ����
				GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  

				// �߷��� �̸��� �ı�
				Destroy(slicedEmoji, 3f);


				//���� �̸����� ũ�⸦ 0���� ����� ���� --- �ٷ� �ı����� �ʴ� ������ ������ ����.
				rect.localScale = new Vector3(0, 0, 0);  
				Destroy(gameObject, 2f);
				soundManager.instance.PlaySound();  //�߸��� ȿ����
				isCut = 1;    // �ٸ� ��ũ��Ʈ���� �� ����.
				dupli = true;

			}

			else if(col.tag == "Misszone")  // MissZone tag�� ���� ������Ʈ�� �浹 ��
			{ 
				rect.localScale = new Vector3(0, 0, 0);
				Destroy(gameObject, 2f);
				isCut = 2;
				dupli = true;
			}
		}
	}

}
