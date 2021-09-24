using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectWrapperController : MonoBehaviour
{
    public Text Name;
    public Text Description;
    public Image ProfileImage;

    public void Init(string name, string description, string imagepath)
    {
        Name.text = name;
        Description.text = description;
        ProfileImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(imagepath);
    }
}
