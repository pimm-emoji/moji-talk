using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �پ��� �ӵ��� �����ϴ� ��ũ��Ʈ�Դϴ�.

public class Circlemanager : MonoBehaviour

{
  
    float scaleSpeed = 0.7f;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
       
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 xyz = rectTransform.localScale;
        
        if (xyz.x >= 0.2)
         { 
            float newx = xyz.x - (scaleSpeed * Time.deltaTime);
            float newy = xyz.x - (scaleSpeed * Time.deltaTime);
            rectTransform.localScale = new Vector3(newx, newy, 0);
         }
        else if(xyz.x < 0.2)
        {
            rectTransform.localScale = new Vector3(0.03f, 0.03f, 0);
        }
    
    

        
    }
}
