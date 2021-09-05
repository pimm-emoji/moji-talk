pusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class texts : MonoBehaviour
{

    GameObject Textbox;
    public Text myText;
    // Start is called before the first frame update

    public void changetext(string name, string intext)
    {
        Textbox = GameObject.Find(name);
        myText = Textbox.GetComponent<Text>();
        myText.text = intext;
    }
    void Start()
    {
        /* 
        if(스테이지 완료 시){
            changetext(1, "스테이지 완료");
        elseif(스테이지 실패시{
            changetext(text1, "스테이지 실패" );

        changetext(text2, "스테이지 이름 받아오기");
        changetext(text3, "엔딩 이름");
        changetext(text4, "이름 획득");
        changetext(text5, "돌아가기");
        changetext(text6, "

        

    }
        
      

}
