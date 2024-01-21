using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class IngameBg : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource BgSound1;
    public AudioClip[] bglist;
    public static IngameBg instance;

    private void Awake()
    {
        if (instance == null)
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
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
                BgSoundPlay(bglist[i]);

        }
    }
    public void BgSoundVolume(float val)
    {
        mixer.SetFloat("BgSoundVolume", Mathf.Log10(val) * 20);
    }
    public void BgSoundPlay(AudioClip clip)
    {
        BgSound1.outputAudioMixerGroup = mixer.FindMatchingGroups("BgSound")[0];
        BgSound1.clip = clip;
        BgSound1.loop = true;
        BgSound1.volume = 0.1f;
        BgSound1.Play();
    }
}
