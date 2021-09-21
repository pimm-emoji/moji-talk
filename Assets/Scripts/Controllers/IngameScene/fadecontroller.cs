using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadecontroller : MonoBehaviour
{
    GameObject SplashObj;
    Image background;
    public bool wait = true;

    public static fadecontroller instance;

    void Start()
    {
        SplashObj = GameObject.FindWithTag("Background");
        background = SplashObj.GetComponent<Image>();
        instance = this;
    }

    public void Fadeout()
    {
        SplashObj.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine("fadeo");
    }

    public void Fadein()
    {
        SplashObj.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine("fadei");   
    }

    IEnumerator fadei()
    {
        float fadeCount = 1f;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.015f;
            yield return new WaitForSeconds(0.01f);
            background.color = new Color(0, 0, 0, fadeCount);


        }
        wait = false;
        SplashObj.transform.localScale = new Vector3(0, 0, 0);
    }


    IEnumerator fadeo()
    {
        float fadeCount = 0f;
        while (fadeCount < 1f)
        {
            fadeCount += 0.015f;
            yield return new WaitForSeconds(0.01f);
            background.color = new Color(0, 0, 0, fadeCount);
        }
        wait = false;
    }



}
