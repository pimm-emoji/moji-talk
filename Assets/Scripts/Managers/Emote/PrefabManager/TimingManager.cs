using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // �̸����� ������ �� ������ �ϴ� ��ũ��Ʈ�Դϴ�.

//�߰� �ʿ� : emojis���� ����ġ �� ��������

public class TimingManager : MonoBehaviour
{
    GameObject circle;
    RectTransform rectTransform;
    Emojis parscript;
    EffectManager theEffect;

    ScoreManager theScoreManager;
    ComboManager theComboManager;

    float emojiscore;
   

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
        rectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        parscript = transform.parent.parent.gameObject.GetComponent<Emojis>();
        theComboManager = FindObjectOfType<ComboManager>();

        emojiscore = parscript.emoji.ondestroy;
       
    }

    // Update is called once per frame
    void Update()
    {
     
        if (parscript.isCut == 1)  //emojis ��ũ��Ʈ���� isCut���� 1�̶��(�߷��� ���� 1��)
        {
            // if ����ġ ���� 0���� ũ�ٸ�
            if(emojiscore > 0f)
            {
                //�پ��� �� ũ���� x ������ ���� ������. �� �� ����
                float scale = rectTransform.localScale.x;
                if (scale >= 32 && scale <= 36)
                {
                    Debug.Log("Perfect");
                    theEffect.JudgementEffect(0);  //0�� ����Ʈ �۵�
                    theScoreManager.IncreaseScore(0, emojiscore);  // 0�� ������� �۵�, �߰��� �� : �̸��� ����ġ �� �޾Ƽ� ���� �Ѱ���
                }

                else if (scale > 36 && scale <= 48)
                {
                    Debug.Log("Cool");
                    theEffect.JudgementEffect(1);
                    theScoreManager.IncreaseScore(1, emojiscore);
                }

                else if (scale > 48 && scale <= 72)
                {
                    Debug.Log("Good");
                    theEffect.JudgementEffect(2);
                    theScoreManager.IncreaseScore(2, emojiscore);
                }

                else if (scale > 72 || scale < 36)
                {
                    Debug.Log("Bad");
                    theComboManager.ResetCombo();
                    theEffect.JudgementEffect(3);
                    theScoreManager.IncreaseScore(3, emojiscore);
                }
            }
            else if(emojiscore <= 0f)
            {
                Debug.Log(emojiscore);
                theComboManager.ResetCombo();
                theEffect.JudgementEffect(3);
                theScoreManager.IncreaseScore(3, emojiscore);

            }

            //if ����ġ ���� 0���� �۴ٸ�(�߰� �ʿ�)

            parscript.isCut = 3;  // �ߺ����� �߸��� ���� ����.
         
      
        }
        else if(parscript.isCut == 2)  // �߸��� ���� �̸����� MISSZone�� ����� ���(misszone�� emojis ��ũ��Ʈ�� ����)
        {
            if(emojiscore > 0f)
            {
                Debug.Log("Miss");
                theComboManager.ResetCombo();
                theEffect.JudgementEffect(4);  
                parscript.isCut = 3;   
            }
            
        }

    }
}
