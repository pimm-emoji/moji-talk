using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEngine.UI.Text txtScore = null;  //스코어를 표시할 텍스트 객체 설정

    [SerializeField] int increaseScore = 10;   //기본 상승 점수
    int currentScore = 0;

    [SerializeField] float[] weight = null;    //판정별 가중치 입력
    [SerializeField] int comboBonusScore = 10;  //콤보 보너스 점수 입력

    ComboManager theCombo;
    void Start()
    {
        theCombo = FindObjectOfType<ComboManager>();   //콤보 매니져 스크립트 불러옴
        currentScore = 0;
        txtScore.text = "0";
    }

    public void IncreaseScore(int p_JudgementState)
    {
        //콤보 증가
        theCombo.IncreaseCombo();

        int t_increaseScore = increaseScore;
        //콤보 가중치 계산
        int t_currentCombo = theCombo.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        //판정 가중치 계산
        t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        //점수반영
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);
    }

}
