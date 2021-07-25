using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEngine.UI.Text txtScore = null;  //���ھ ǥ���� �ؽ�Ʈ ��ü ����

    [SerializeField] int increaseScore = 10;   //�⺻ ��� ����
    int currentScore = 0;

    [SerializeField] float[] weight = null;    //������ ����ġ �Է�
    [SerializeField] int comboBonusScore = 10;  //�޺� ���ʽ� ���� �Է�

    ComboManager theCombo;
    void Start()
    {
        theCombo = FindObjectOfType<ComboManager>();   //�޺� �Ŵ��� ��ũ��Ʈ �ҷ���
        currentScore = 0;
        txtScore.text = "0";
    }

    public void IncreaseScore(int p_JudgementState)
    {
        //�޺� ����
        theCombo.IncreaseCombo();

        int t_increaseScore = increaseScore;
        //�޺� ����ġ ���
        int t_currentCombo = theCombo.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        //���� ����ġ ���
        t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        //�����ݿ�
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);
    }

}
