using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewContentController : MonoBehaviour
{
    public ScrollViewContentPositionCofiguration positioningConfig;
    public float nextMessagePosition = 40;
    public void AddChild(GameObject childObject)
    {
        childObject.transform.SetParent(gameObject.transform);
        childObject.transform.position = new Vector2(0, nextMessagePosition + positioningConfig.marginTop);
        Vector2 viewContentRectSize = GetComponent<RectTransform>().sizeDelta;
        float objectHeight = childObject.GetComponent<RectTransform>().sizeDelta.y;
        nextMessagePosition += objectHeight + positioningConfig.marginBottom + positioningConfig.marginVerticalIntersection;
        GetComponent<RectTransform>().sizeDelta = new Vector2(
            viewContentRectSize.x,
            Math.Abs(viewContentRectSize.y + objectHeight + positioningConfig.marginTop + positioningConfig.marginBottom + positioningConfig.marginVerticalIntersection) * -1
        );
    }
}

[System.Serializable]
public class ScrollViewContentPositionCofiguration
{
    public float marginTop = 0;
    public float marginBottom = 0;
    public float marginLeft = 0;
    public float marginRight = 0;
    public float marginVerticalIntersection = 30;
}
