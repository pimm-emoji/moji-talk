using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	public GameObject bladeTrailPrefab;       
	public float minCuttingVelocity = 0f;  

	bool isCutting = false;

	Vector2 previousPosition;  // 2차원 벡터 변수 previousPosition

	GameObject currentBladeTrail;  // 

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start ()  // 카메라, 리지드바디, circlecollider 초기값 입력
	{
		cam = Camera.main;  
		rb = GetComponent<Rigidbody2D>(); //
		circleCollider = GetComponent<CircleCollider2D>();
	}


	void Update () {  //마우스 입력에 따라서 업데이트
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
			int ran = Random.Range(0, 2);
			if(ran == 0)
				AudioManager.instance.PlaySFX("swish1");
			else if(ran == 1)

				AudioManager.instance.PlaySFX("swish2");
			else
				AudioManager.instance.PlaySFX("swish3");

		} 
		
		else if (Input.GetMouseButtonUp(0))
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

		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);  // 마우스의 좌표를 받아서 newposition에 저장함. 그 후 리지드 바디로 넘겨줌 
        rb.position = newPosition;

		//float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime; // 초당 이동한 거리를 minCuttingVelocity와 비교 후 circlecollider의 활성화 여부 결정.
		



		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform); //bladetail 오브젝트 생성
		

		circleCollider.enabled = true;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f); // 2f 후에 currentbladetrail 삭제
		circleCollider.enabled = false;
	}

}
