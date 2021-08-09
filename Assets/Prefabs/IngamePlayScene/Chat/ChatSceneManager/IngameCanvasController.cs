using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameCanvasController : MonoBehaviour
{
    public Canvas userListPanel;
    int processing = 0; // 0: Stop, 1: Hide (display -> none), 2: Show (none -> display)
    float duration = 5;
    float easingTime;
    float currentTime = 0;
    float normalizedTime;
    Vector3 hidePosition = new Vector3();
    Vector3 showPosition = new Vector3();
    RectTransform rectTransform;
    IEnumerator LerpObject(Vector3 init, Vector3 fin)
    {
        while (currentTime <= easingTime)
        {
            currentTime += Time.deltaTime;
            normalizedTime = currentTime / easingTime;
            rectTransform.anchoredPosition = Vector3.Lerp(init, fin, normalizedTime);
            yield return null;
        }
        if (currentTime > easingTime) processing = 0;
    }

    void Start()
    {
        rectTransform = userListPanel.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (processing > 0)
        {
            if (processing == 1) LerpObject(showPosition, hidePosition);
            else LerpObject(showPosition, hidePosition);
        }
    }

    [ContextMenu("Show Canvas")]
    public void ShowCanvas() {}

    [ContextMenu("Hide Canvas")]
    public void HideCanvas() {}
}
