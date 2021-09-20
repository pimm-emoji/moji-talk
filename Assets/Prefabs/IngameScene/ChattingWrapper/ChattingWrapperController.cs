using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChattingWrapperController : MonoBehaviour
{
    public GameObject nameWrapper;
    public GameObject contentWrapper;
    public Text nameText;
    public Text contentText;

    public void Init(string Name, string Content, int Align) // Align => Left : Right ? is 0
    {
        RectTransform nameWrapperRect = nameWrapper.GetComponent<RectTransform>();
        RectTransform contentWrapperRect = contentWrapper.GetComponent<RectTransform>();
        nameText.text = Name;
        contentText.text = Content;
        nameWrapperRect.sizeDelta = new Vector2(
            nameText.preferredWidth + ChattingConfig.namePadding[0] * 2,
            nameText.preferredHeight + ChattingConfig.namePadding[1] * 2
        );
        contentWrapperRect.sizeDelta = new Vector2(
            contentText.preferredWidth + ChattingConfig.contentPadding[0] * 2,
            contentText.preferredHeight + ChattingConfig.contentPadding[1] * 2
        );

        if (Align == 0)
        {
            nameWrapperRect.anchorMin = ChattingWrapperRect.Left.anchorMin;
            nameWrapperRect.anchorMax = ChattingWrapperRect.Left.anchorMax;
            nameWrapperRect.pivot = ChattingWrapperRect.Left.childPivot;
            contentWrapperRect.anchorMin = ChattingWrapperRect.Left.anchorMin;
            contentWrapperRect.anchorMax = ChattingWrapperRect.Left.anchorMax;
            contentWrapperRect.pivot = ChattingWrapperRect.Left.pivot;
        }
        else
        {
            nameWrapperRect.anchorMin = ChattingWrapperRect.Right.anchorMin;
            nameWrapperRect.anchorMax = ChattingWrapperRect.Right.anchorMax;
            nameWrapperRect.pivot = ChattingWrapperRect.Right.childPivot;
            contentWrapperRect.anchorMin = ChattingWrapperRect.Right.anchorMin;
            contentWrapperRect.anchorMax = ChattingWrapperRect.Right.anchorMax;
            contentWrapperRect.pivot = ChattingWrapperRect.Right.pivot;
        }
    }
    
    [ContextMenu("Debug Chattings (Left)")]
    void DebugInitLeft() { Init("Cally Carly Davidson", "캘리컬리, \n캘리컬리 데이비슨. 이게 내 이름이야.", 0); }

    [ContextMenu("Debug Chattings (Right)")]
    void DebugInitRight() { Init("Cally Carly Davidson", "고맙네 할멈.", 1); }
}
