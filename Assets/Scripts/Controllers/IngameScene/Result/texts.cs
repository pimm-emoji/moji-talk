using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class texts : MonoBehaviour
{
    //어떤 leveldata를 불러와야 하는가?  loadstorage하면 leveldata의 리스트가 나오는데 이중 어떤거? 혹은 이미 다른 스크립트에서 함수 지정?
    LevelData CurLevelData;

    UserData userData = UserDataManager.LoadStorage();
    int intData;
    //userData.unlockedLevelData.Find(x => x.id == "현재의 레벨 아이디").endings.Find(x => x.id == 'a')

    public GameObject UI;
    public GameObject AchvPrefab;
    GameObject Textbox;
    public Text myText;
    // Start is called before the first frame update
    public bool[] achvlist = new bool[] { true, false, false, true }; //업적 클리어 여부  판단은 어떻게?
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
        // CurLevelData = UserDataManager.LoadStorage()[0];


        if (stageclear == true){ // CurLevelData.endings[i].id
            changetext("text1", "스테이지 완료");
        }
        else if(stageclear == false){
            changetext("text1", "스테이지 실패" );
        }

        changetext("text2", "스테이지 이름 받아오기"); // CurLevelData.endings[i].name
        changetext("text3", "엔딩 이름");// '' 변수.Name 넣기
        changetext("text4", "이름 획득");
        changetext("text5", "돌아가기");

        //CurLevelData.isCleared = true;
        //UserDataManager.SaveStorage(CurLevelData);
        
        for(int i = 0; i < achvlist.Length; i++){
            
            

            if(achvlist[i] == true){
                Text bigtext;
                Text smalltext;

                float y = (float)850 - 142 * t;
                UI = GameObject.Find("UI");
   
                GameObject newAchvPrefab = Instantiate(AchvPrefab, new Vector3(1630f, y, 0), Quaternion.identity);
                newAchvPrefab.transform.parent = UI.transform;
                GameObject AchvBig = newAchvPrefab.transform.GetChild(1).gameObject;
                GameObject AchvSmall = newAchvPrefab.transform.GetChild(2).gameObject;
                bigtext = AchvBig.GetComponent<Text>();
                smalltext = AchvSmall.GetComponent<Text>();
                bigtext.text = "i번째 업적 이름 받아오기";
                smalltext.text = "i번째 업적 내용받아오기";
            
                t += 1;
                }
        }



          




    }



}
