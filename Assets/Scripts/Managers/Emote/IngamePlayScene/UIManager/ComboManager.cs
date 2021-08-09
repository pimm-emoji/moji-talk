using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    // �޺� �̹��� �� �ؽ�Ʈ ����
    [SerializeField] GameObject goComboImage = null;
    [SerializeField] UnityEngine.UI.Text txtCombo = null;

    int currentCombo = 0;

    //ó������ ��Ȱ��ȭ
    void Start()
    {
        txtCombo.gameObject.SetActive(false);  
        goComboImage.SetActive(false);
    }

    //�޺��� ������Ű�� �Լ�
    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        //2�޺� �ʰ� �� �̹���, �ؽ�Ʈ Ȱ��ȭ
        if(currentCombo > 2)
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);
        }
    }

    //���� �޺��� ��ȯ���ִ� �Լ�
    public int GetCurrentCombo()
    {
        return currentCombo;
    }


    //�޺��� ���½�Ű�� �Լ�
    public void ResetCombo()
    {
        currentCombo = 0;
        txtCombo.text = "0";
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }



  

    // Update is called once per frame
    void Update()
    {
        
    }
}