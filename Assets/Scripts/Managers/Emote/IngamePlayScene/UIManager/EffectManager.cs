using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ����Ʈ ������ ����ϴ� ��ũ��Ʈ�Դϴ�.
public class EffectManager : MonoBehaviour
{
    //Hit �̶�� ���ڿ��� �ִϸ��̼��� �����Ű�� Ʈ������
    string hit = "Hit";
    
    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementlmage = null;

    // ��������Ʈ ����
    [SerializeField] Sprite[] judgementSprite = null;
    


    // �Ķ���� ���� ���� judgementSprite �迭���� �ش� ��������Ʈ�� ������
    public void JudgementEffect(int p_num)
    {
        judgementlmage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }

}
 