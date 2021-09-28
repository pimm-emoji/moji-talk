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
    AudioManager theAudioManager;

    float emojiscore;
    float distance;
   

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        theEffect = FindObjectOfType<EffectManager>();
        rectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        parscript = transform.parent.parent.gameObject.GetComponent<Emojis>();
        theComboManager = FindObjectOfType<ComboManager>();
        theAudioManager = AudioManager.instance;

        emojiscore = parscript.emoji.ondestroy;
       
    }

    // Update is called once per frame
    void Update()
    {
     
        if (parscript.isCut == 1)  //emojis 스크립트에서 isCut값이 1이라면(잘렸을 때가 1임)
        {
            distance = parscript.distance;
            Debug.Log(distance);
            // if 가중치 값이 0보다 크다면
            if (emojiscore > 0f)
            {
                if (distance <= 30f)
                {
                    Debug.Log("Perfect");
                    theEffect.JudgementEffect(0);  //0번 이펙트 작동
                    theEffect.ScoreEffect();
                    theScoreManager.IncreaseScore(0, emojiscore);  // 0번 점수상승 작동, 추가할 것 : 이모지 가중치 값 받아서 같이 넘겨줌
                    theAudioManager.PlaySFX("Touch");
                    GameManager.instance.AddPerfect();
                }

                else if (distance > 30f && distance<= 60f)
                {
                    Debug.Log("Cool");
                    theEffect.JudgementEffect(1);
                    theEffect.ScoreEffect();
                    theScoreManager.IncreaseScore(1, emojiscore);
                    theAudioManager.PlaySFX("Touch");
                    GameManager.instance.AddGreat();
                }

                else if ((distance > 60f && distance <= 200f)||distance == 500f)
                {
                    Debug.Log("Good");
                    theEffect.JudgementEffect(2);

                    theScoreManager.IncreaseScore(2, emojiscore);
                    theAudioManager.PlaySFX("Touch");
                    GameManager.instance.AddGood();
                }

                else if (distance > 200f && distance < 500f)
                {
                    Debug.Log("Bad");
                    theComboManager.ResetCombo();
                    theEffect.JudgementEffect(3);
                    theEffect.ScoreEffect();
                    theScoreManager.IncreaseScore(3, emojiscore);
                    theAudioManager.PlaySFX("Touch");
                    GameManager.instance.AddBad();
                }
                
            }
            else if(emojiscore <= 0f)
            {
                Debug.Log(emojiscore);
                theComboManager.ResetCombo();
                theEffect.JudgementEffect(3);
                theEffect.ScoreEffect();
                theScoreManager.IncreaseScore(3, emojiscore);
                theAudioManager.PlaySFX("Touch");
                GameManager.instance.AddBad();

            }

            parscript.isCut = 3;  // 중복으로 잘리는 것을 방지.
         
      
        }
        else if(parscript.isCut == 2)  // 잘리지 않은 이모지가 MISSZone에 닿았을 경우(misszone은 emojis 스크립트에 등장)
        {
            if(emojiscore > 0f)
            {
                Debug.Log("Miss");
                theComboManager.ResetCombo();
                theScoreManager.IncreaseScore(4, emojiscore);
                theEffect.JudgementEffect(4);
                theEffect.ScoreEffect();
                parscript.isCut = 3;
                GameManager.instance.AddMiss();
            }
            
        }

    }
}
