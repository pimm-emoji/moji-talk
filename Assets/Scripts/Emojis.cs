using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emojis : MonoBehaviour {

	public GameObject emojiSlicedPrefab; //emojislicedprefab , startforce ����
	public float startForce = 15f;
<<<<<<< Updated upstream

	Rigidbody2D rb;
=======
	public int isCut = 0;
	bool dupli = false;

	Rigidbody2D rb;
	RectTransform rect;

>>>>>>> Stashed changes

	void Start ()  //rigidbody�� ���� ���� ����
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
<<<<<<< Updated upstream
=======
		rect = GetComponent<RectTransform>();

>>>>>>> Stashed changes
	}

	void OnTriggerEnter2D (Collider2D col)  //Blade �±׸� ���� ������Ʈ�� �浹 ��
	{
<<<<<<< Updated upstream
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction); //

			GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  // �߸� ���� ������Ʈ ����
			Destroy(slicedEmoji, 3f);
			Destroy(gameObject);
=======
		if (dupli == false)
		{
			if (col.tag == "Blade")
			{

				Vector3 direction = (col.transform.position - transform.position).normalized;

				Quaternion rotation = Quaternion.LookRotation(direction); //

				GameObject slicedEmoji = Instantiate(emojiSlicedPrefab, transform.position, rotation);  // �߸� ���� ������Ʈ ����

				
				Destroy(slicedEmoji, 3f);

				rect.localScale = new Vector3(0, 0, 0);
				Destroy(gameObject, 2f);
				soundManager.instance.PlaySound();
				isCut = 1;
				dupli = true;

			}

			else if(col.tag == "Misszone")
			{ 
				rect.localScale = new Vector3(0, 0, 0);
				Destroy(gameObject, 2f);
				isCut = 2;
				dupli = true;
			}
		
		
>>>>>>> Stashed changes
		}
	}

}
