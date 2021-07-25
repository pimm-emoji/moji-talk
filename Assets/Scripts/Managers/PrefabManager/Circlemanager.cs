using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �پ��� �ӵ��� �����ϴ� ��ũ��Ʈ�Դϴ�.

public class Circlemanager : MonoBehaviour

{
  
    float scaleSpeed = 50f;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
       
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 xyz = rectTransform.localScale;
        
        if (xyz.x >= 1)
         { 
            float newx = xyz.x - (scaleSpeed * Time.deltaTime);
            float newy = xyz.x - (scaleSpeed * Time.deltaTime);
            rectTransform.localScale = new Vector3(newx, newy, 0);
         }
        else if(xyz.x < 1)
        {
            rectTransform.localScale = new Vector3(0.03f, 0.03f, 0);
        }
    
    

        
    }
}
