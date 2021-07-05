using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrapperController : MonoBehaviour
{
    public Text Name;
    public Text Description;
    public Image ProfileImage;

    public void Init(string name, string description, string imagepath)
    {
        Name.text = name;
        Description.text = description;
        ProfileImage.sprite = Resources.Load<Sprite>(imagepath);
    }
}
