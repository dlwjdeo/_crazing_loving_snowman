using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SoundManager : MonoBehaviour
{

    public AudioSource BgSound;
    public AudioClip[] bglist;
    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    private void OnSceneLoaded(Scene arg0,LoadSceneMode arg1)
    {
        for(int i=0;i<bglist.Length; i++)
        {
            if(arg0.name==bglist[i].name)
                BgSoundPlay(bglist[i]);
            
        }
        if (SceneManager.GetActiveScene().name == "GameScene1" || SceneManager.GetActiveScene().name == "GameScene2" || SceneManager.GetActiveScene().name == "GameScene3" || SceneManager.GetActiveScene().name == "GameScene4")
        {
            BgSound.Stop();
        }
    }
  

    public void BgSoundPlay(AudioClip clip)
    {
       
        BgSound.clip = clip;
        BgSound.loop = true;
        BgSound.volume = 0.1f;
        BgSound.Play();
        
    }



}
