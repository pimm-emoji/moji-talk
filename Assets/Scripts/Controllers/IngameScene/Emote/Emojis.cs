using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; //emojislicedprefab , startforce ����
	public float startForce = 15f;
	
	public int isCut = 0; 
	bool dupli = false;

	Rigidbody2D rb;
	RectTransform rect;   

	void Start ()  
	{
		rb = GetComponent<Rigidbody2D>();             //rigidbody�� ���� ���� ����
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

		rect = GetComponent<RectTransform>();  //���� �̸����� Transform ������

	}

	void OnTriggerEnter2D (Collider2D col)  //�浹 ��
	{

		if (dupli == false)   // �ߺ����� �߸��� ����
		{
			if (col.tag == "Blade")  //Blade �±׸� ���� ������Ʈ�� �浹 ��
			{

				Vector3 direction = (col.transform.position - transform.position).normalized;
				Quaternion rotation = (Quaternion.LookRotation(forward : Vector3.forward, upwards : direction)); //

			
			

				GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  // �߸� ���� ������Ʈ ����

				
				Destroy(slicedEmoji, 3f);

				rect.localScale = new Vector3(0, 0, 0);  // ũ�⸦ 0���� ����� ���� --- �ٷ� �ı����� �ʴ� ������ ������ ����.
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
