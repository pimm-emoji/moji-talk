using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewContentController : MonoBehaviour
{
    public ScrollViewContentPositionCofiguration positioningConfig;
    public float nextMessagePosition = 40;

    public void AddChild(GameObject childObject, int Align)
    {
        childObject.transform.SetParent(gameObject.transform);
        childObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            (positioningConfig.marginHorizontalBorder) * (Align == 0 ? 1 : -1) + positioningConfig.marginLeft + positioningConfig.marginRight * -1,
            (nextMessagePosition + positioningConfig.marginTop) * -1
        );
        Vector2 viewContentRectSize = GetComponent<RectTransform>().sizeDelta;
        float objectHeight = childObject.GetComponent<RectTransform>().sizeDelta.y;
        nextMessagePosition += objectHeight + positioningConfig.marginBottom + positioningConfig.marginVerticalIntersection;
        GetComponent<RectTransform>().sizeDelta = new Vector2(
            viewContentRectSize.x,
            viewContentRectSize.y + objectHeight + positioningConfig.marginTop + positioningConfig.marginBottom + positioningConfig.marginVerticalIntersection
        );
    }

    public ScrollViewContentControllerDebuggerConfiguration debugVariables;
    public void DebugAddChild(int Align)
    {
        GameObject newObject = Instantiate(debugVariables.chattingWrapperPrefab) as GameObject;
        newObject.GetComponent<ChattingWrapperController>().Init("##NAME##", "##CONTENT##", Align);
        AddChild(newObject, Align);
    }
    [ContextMenu("Debug Add Child (Left)")] public void DebugAddChildLeft() { DebugAddChild(0); }
    [ContextMenu("Debug Add Child (Right)")] public void DebugAddChildRight() { DebugAddChild(1); }
}

[System.Serializable]
public class ScrollViewContentPositionCofiguration
{
    public float marginTop = 0;
    public float marginBottom = 0;
    public float marginLeft = 0;
    public float marginRight = 0;
    public float marginVerticalIntersection = 40;
    public float marginHorizontalBorder = 10;
}

[System.Serializable]
public class ScrollViewContentControllerDebuggerConfiguration
{
    public GameObject chattingWrapperPrefab;
}