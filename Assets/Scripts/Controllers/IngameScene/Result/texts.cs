using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class texts : MonoBehaviour
{
    public GameObject AchvPrefab;
    GameObject Textbox;
    public Text myText;
    // Start is called before the first frame update
    public bool[] achvlist = new bool[] { true, false, false, true };
    int t = 0;
    bool stageclear = true;

    public void changetext(string name, string intext)
    {
        Textbox = GameObject.Find(name);
        myText = Textbox.GetComponent<Text>();
        myText.text = intext;
       
    }
    void Start()
    {
        if(stageclear == true){
            changetext("text1", "스테이지 완료");
        }
        else if(stageclear == false){
            changetext("text1", "스테이지 실패" );
        }

        changetext("text2", "스테이지 이름 받아오기");
        changetext("text3", "엔딩 이름");
        changetext("text4", "이름 획득");
        changetext("text5", "돌아가기");

        //*업적 달성 배열 만들고 (true, false로 나타내는 배열 만들기)
        
        for(int i = 0; i < achvlist.Length; i++){
            
            

            if(achvlist[i] == true){
                Text bigtext;
                Text smalltext;

                float y = (float)307.5 - 15 * t;
   
                GameObject newAchvPrefab = Instantiate(AchvPrefab, new Vector3(668.5f, y, 0), Quaternion.identity);
                GameObject AchvBig = newAchvPrefab.transform.GetChild(0).gameObject;
                GameObject AchvSmall = newAchvPrefab.transform.GetChild(1).gameObject;
                bigtext = AchvBig.GetComponent<Text>();
                smalltext = AchvSmall.GetComponent<Text>();
                bigtext.text = "i번째 업적 이름 받아오기";
                smalltext.text = "i번째 업적 내용받아오기";
            
                t += 1;
                }
        }



          




    }



}
