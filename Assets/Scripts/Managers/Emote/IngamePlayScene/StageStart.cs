using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        fadecontroller.instance.Fadein();
        AudioManager.instance.PlayBGM("stage1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
