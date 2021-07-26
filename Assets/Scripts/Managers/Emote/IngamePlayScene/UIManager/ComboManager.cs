using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    // 콤보 이미지 및 텍스트 지정
    [SerializeField] GameObject goComboImage = null;
    [SerializeField] UnityEngine.UI.Text txtCombo = null;

    int currentCombo = 0;

    //처음에는 비활성화
    void Start()
    {
        txtCombo.gameObject.SetActive(false);  
        goComboImage.SetActive(false);
    }

    //콤보를 증가시키는 함수
    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        //2콤보 초과 시 이미지, 텍스트 활성화
        if(currentCombo > 2)
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);
        }
    }

    //현재 콤보를 반환해주는 함수
    public int GetCurrentCombo()
    {
        return currentCombo;
    }


    //콤보를 리셋시키는 함수
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
