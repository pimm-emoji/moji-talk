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
    public static AudioManager instance;   //instance ����

    [SerializeField] Sound[] sfx = null;    
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;
    
    void Start()
    {
        instance = this;
    }

    public void PlayBGM(string p_bgmName)   // �Է¹��� �Ķ���Ͱ� bgm �迭 �ȿ� ���� �� 
    {
        for(int i = 0; i<bgm.Length; i++)
        {
            if(p_bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;   //�ش� ����� Ŭ������ ������ ���
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();            // bgm ����
    }

    public void PlaySFX(string p_sfxName)  // �Է¹��� �Ķ���Ͱ� sfxName �ȿ� ���� ��
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (p_sfxName == sfx[i].name)
            {
                for(int x= 0; x< sfxPlayer.Length; x++)   //sfx�÷��̾ �� ���ִ°�?
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfx[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("��� ����� �÷��̾ ������Դϴ�.");
                return;
            }
        }

        Debug.Log(p_sfxName + "�̸��� ȿ������ �����ϴ�.");
    }

}
