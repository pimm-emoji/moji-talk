using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWrapperController : MonoBehaviour
{
    public GameObject Background;
    public Text Text;

    public void Init(string text)
    {
        Text.text = text;
        Background.GetComponent<RectTransform>().sizeDelta = Text.GetComponent<RectTransform>().sizeDelta;
    }
}
