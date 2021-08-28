using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ondestroy 값 필요
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEngine.UI.Text txtScore = null;  //스코어를 표시할 텍스트 객체 설정

    [SerializeField] float increaseScore = 1000f;   //기본 상승 점수

    float currentScore;
    int IntcurrentScore;

    [SerializeField] float[] weight = null;    //판정별 가중치 입력
    [SerializeField] int comboBonusScore = 100;  //콤보 보너스 점수 입력

    ComboManager theCombo;
    void Start()
    {
        GameManager.instance.InitScore();
        GameManager.instance.InitBranchScore();
        theCombo = FindObjectOfType<ComboManager>();   //콤보 매니져 스크립트 불러옴
        currentScore = 0f;
        txtScore.text = "0";
    }

    public void IncreaseScore(int p_JudgementState, float ondestroy)  //파라미터 한개 더 추가하기 (이모지가중치)
    {
        //콤보 증가
        theCombo.IncreaseCombo();

        
        float t_increaseScore = increaseScore;

        //콤보 가중치 계산
        int t_currentCombo = theCombo.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        //판정 가중치 계산
        t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = t_increaseScore * weight[p_JudgementState] * ondestroy;

        GameManager.instance.AddScore(t_increaseScore);


        //점수반영
        currentScore = GameManager.instance.GetScore();
        IntcurrentScore = (int)currentScore;
   
        txtScore.text = string.Format("{0:#,##0}", IntcurrentScore);
    }

}
