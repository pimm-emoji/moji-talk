using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//판정의 이펙트 연출을 담당하는 스크립트입니다.
public class EffectManager : MonoBehaviour
{
    //Hit 이라는 문자열이 애니메이션을 실행시키는 트리거임
    string hit = "Hit";
    string good = "goodend";
    string normal = "normalend";
    string bad = "badend";
    string gameover = "gameover";
    
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementlmage = null;
    [SerializeField] Animator scoreAnimator = null;
    [SerializeField] Animator Goodending = null;
    [SerializeField] Animator Normalending = null;
    [SerializeField] Animator Badending = null;
    [SerializeField] Animator Gameoverend = null;



    // 스프라이트 선택
    [SerializeField] Sprite[] judgementSprite = null;
    


    // 파라미터 값에 따라 judgementSprite 배열에서 해당 스프라이트를 가져옴
    public void JudgementEffect(int p_num)
    {
        judgementlmage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }

    public void Goodend()
    {
        Goodending.SetTrigger(good);
    }

    public void Normalend()
    {
        Normalending.SetTrigger(normal);
    }

    public void Badend()
    {
        Badending.SetTrigger(bad);
    }

    public void Gameover()
    {
        Gameoverend.SetTrigger(gameover);
    }


    public void ScoreEffect()
    {
        scoreAnimator.SetTrigger(hit);
    }

}
 