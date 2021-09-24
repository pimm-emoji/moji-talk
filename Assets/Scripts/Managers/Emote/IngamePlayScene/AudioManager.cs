using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Managing SFX, BGM

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;   //instance 생성

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

    void Start()
    {
        instance = this;
    }

    public void PlayBGM(string p_bgmName)   // 입력받은 파라미터가 bgm 배열 안에 있을 시 
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (p_bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;   //해당 오디오 클립으로 설정후 재생
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();            // bgm 정지
    }

    public void PlaySFX(string p_sfxName)  // 입력받은 파라미터가 sfxName 안에 있을 시
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)   //sfx플레이어가 꽉 차있는가?
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("모든 오디오 플레이어가 재생중입니다.");
                return;
            }
        }

        Debug.Log(p_sfxName + "이름의 효과음이 없습니다.");
    }

}