using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // 이모지를 베었을 때 판정을 하는 스크립트입니다.

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
     
        if (parscript.isCut == 1)  //emojis 스크립트에서 isCut값이 1이라면(잘렸을 때가 1임)
        {

            //줄어드는 원 크기의 x 스케일 값을 가져옴. 그 후 판정
            float scale = rectTransform.localScale.x;  
            if (scale >= 32 && scale <= 36)
            {
                Debug.Log("Perfect");
                theEffect.JudgementEffect(0);  //0번 이펙트 작동
                theScoreManager.IncreaseScore(0);  // 0번 점수상승 작동
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

            parscript.isCut = 3;  // 중복으로 잘리는 것을 방지.
         
      
        }
        else if(parscript.isCut == 2)  // 잘리지 않은 이모지가 MISSZone에 닿았을 경우(misszone은 emojis 스크립트에 등장)
        {
            Debug.Log("Miss");
            theComboManager.ResetCombo();
            theEffect.JudgementEffect(4);  
            parscript.isCut = 3;   
        }

    }
}
