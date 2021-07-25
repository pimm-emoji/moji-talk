using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // �̸����� ������ �� ������ �ϴ� ��ũ��Ʈ�Դϴ�.

public class TimingManager : MonoBehaviour
{
    GameObject circle;
    RectTransform rectTransform;
    Emojis parscript;
    EffectManager theEffect;

    ScoreManager theScoreManager;
    ComboManager theComboManager;

   

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
        rectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        parscript = transform.parent.parent.gameObject.GetComponent<Emojis>();
        theComboManager = FindObjectOfType<ComboManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
     
        if (parscript.isCut == 1)  //emojis ��ũ��Ʈ���� isCut���� 1�̶��(�߷��� ���� 1��)
        {

            //�پ��� �� ũ���� x ������ ���� ������. �� �� ����
            float scale = rectTransform.localScale.x;  
            if (scale >= 32 && scale <= 36)
            {
                Debug.Log("Perfect");
                theEffect.JudgementEffect(0);  //0�� ����Ʈ �۵�
                theScoreManager.IncreaseScore(0);  // 0�� ������� �۵�
            }

             else if (scale > 36 && scale <= 48)
             {
                Debug.Log("Cool");
                theEffect.JudgementEffect(1);
                theScoreManager.IncreaseScore(1);
            }

             else if (scale > 48 && scale <= 72)
             {
                Debug.Log("Good");
                theEffect.JudgementEffect(2);
                theScoreManager.IncreaseScore(2);
            }

             else if (scale > 72 || scale < 36)
             {
                Debug.Log("Bad");
                theComboManager.ResetCombo();
                theEffect.JudgementEffect(3);
                theScoreManager.IncreaseScore(3);
            }

            parscript.isCut = 3;  // �ߺ����� �߸��� ���� ����.
         
      
        }
        else if(parscript.isCut == 2)  // �߸��� ���� �̸����� MISSZone�� ����� ���(misszone�� emojis ��ũ��Ʈ�� ����)
        {
            Debug.Log("Miss");
            theComboManager.ResetCombo();
            theEffect.JudgementEffect(4);  
            parscript.isCut = 3;   
        }

    }
}
