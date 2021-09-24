using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchToStart : MonoBehaviour
{
    public string SceneToLoad;
   
    bool dupl = false; // mousebuttondown은 한번만 클릭될 수 있음
    bool nextscene = false; //startcoroutine과 loadscene을 같이 두면 코루틴 실행이 안되서 클릭 시 nextscene이 true가 되게 해놓음.
    bool finished = false;// startcoroutine이 끝나면 finished 활성화, nextscene, finsished 둘 다 true 일 시 씬 전환.


    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    // Start is called before the first frame update

    void Start() 
    {
        AudioManager.instance.PlayBGM("TITLE");
    }

    // Update is called once per frame
    void Update()
    {
        if (dupl == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fadecontroller.instance.Fadeout();
                AudioManager.instance.PlaySFX("menutouch1");
            }
        }

        if (fadecontroller.instance.wait == false)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
