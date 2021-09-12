using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchToStart : MonoBehaviour
{
    public string SceneToLoad;
    GameObject SplashObj;
    Image titleimage;
    bool nextscene = false;
    bool finished = false;


    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    // Start is called before the first frame update
    void Start() 
    {
        SplashObj = this.transform.GetChild(0).gameObject;
        titleimage = SplashObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextscene = true;
            StartCoroutine("MainSplash");
            
        }

        if (nextscene == true && finished == true)
        {
            SceneManager.LoadScene(SceneToLoad);
        }

    }

    IEnumerator MainSplash()
    {                           
        float fadeCount = 1f;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            titleimage.color = new Color(1, 1, 1, fadeCount);
            

        }
        finished = true;
    }
}
