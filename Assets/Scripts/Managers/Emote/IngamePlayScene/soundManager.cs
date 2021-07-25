using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioClip soundDestroy;
    AudioSource myAudio;
    public static soundManager instance;

    void Awake()
    {
        if(soundManager.instance == null)
        {
            soundManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public void PlaySound() 
    {
        myAudio.PlayOneShot(soundDestroy);
    }
}
