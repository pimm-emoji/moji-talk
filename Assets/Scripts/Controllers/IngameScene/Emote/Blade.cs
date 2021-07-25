using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	public GameObject bladeTrailPrefab;       
	public float minCuttingVelocity = .001f;  

	bool isCutting = false;

	Vector2 previousPosition;  // 2���� ���� ���� previousPosition

	GameObject currentBladeTrail;  // 

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start ()  // ī�޶�, ������ٵ�, circlecollider �ʱⰪ �Է�
	{
		cam = Camera.main;  
		rb = GetComponent<Rigidbody2D>(); //
		circleCollider = GetComponent<CircleCollider2D>();
	}


	void Update () {  //���콺 �Է¿� ���� ������Ʈ
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		} else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}
		
	}

	void UpdateCut ()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);  // ���콺�� ��ǥ�� �޾Ƽ� newposition�� ������. �� �� ������ �ٵ�� �Ѱ��� 
        rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime; // �ʴ� �̵��� �Ÿ��� minCuttingVelocity�� �� �� circlecollider�� Ȱ��ȭ ���� ����.
		if (velocity >= minCuttingVelocity)
		{
			circleCollider.enabled = true;
		} else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform); //bladetail ������Ʈ ����
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f); // 2f �Ŀ� currentbladetrail ����
		circleCollider.enabled = false;
	}

}
