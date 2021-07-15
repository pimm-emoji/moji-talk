using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    string hit = "Hit";
    
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementlmage = null;
    [SerializeField] Sprite[] judgementSprite = null;
    

    // Start is called before the first frame update


    public void JudgementEffect(int p_num)
    {
        judgementlmage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }

}
 