using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; //emojislicedprefab , startforce ����
	public float startForce = 15f;

	Rigidbody2D rb;

	void Start ()  //rigidbody�� ���� ���� ����
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D col)  //Blade �±׸� ���� ������Ʈ�� �浹 ��
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction); //

			GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  // �߸� ���� ������Ʈ ����
			Destroy(slicedEmoji, 3f);
			Destroy(gameObject);
		}
	}

}
