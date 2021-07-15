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

   


    // Start is called before the first frame update
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
     
        if (parscript.isCut == 1)
        {

            float scale = rectTransform.localScale.x;
            if (scale >= 32 && scale <= 36)
            {
                Debug.Log("Perfect");
                theEffect.JudgementEffect(0);
                theScoreManager.IncreaseScore(0);
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

            parscript.isCut = 3;
         
      
        }
        else if(parscript.isCut == 2)
        {
            Debug.Log("Miss");
            theComboManager.ResetCombo();
            theEffect.JudgementEffect(4);
            parscript.isCut = 3;
        }

    }
}
