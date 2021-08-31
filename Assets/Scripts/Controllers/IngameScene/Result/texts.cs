using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class texts : MonoBehaviour
{

    GameObject Textbox;
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 14; i++)
        {

            string textname = string.Format("text{0}", i);
            Debug.Log(textname);
            Textbox = GameObject.Find(textname);
            myText = Textbox.GetComponent<Text>();
            switch (i)
            {
                case 1:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 2:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 3:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 4:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 5:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 6:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 7:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 8:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 9:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 10:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 11:
                    myText.text = "텍스트를 입력하세요";
                    break;
                case 12:
                    myText.text ="텍스트를 입력하세요";
                    break;
                case 13:
                    myText.text = "텍스트를 입력하세요";
                    break;

            }
        }
    }

}
