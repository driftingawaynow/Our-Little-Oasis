using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] private AudioMixer myAudioMixer;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume") || !PlayerPrefs.HasKey("sfxVolume"))
            if(!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 1);
                Load();
            }
            if(!PlayerPrefs.HasKey("sfxVolume"))
            {
                PlayerPrefs.SetFloat("sfxVolume", 1);
                Load();
            }
        else
        {
            Load();
        }
    }

    public void ChangeMusicVolume()
    {
        myAudioMixer.SetFloat("musicVolume", Mathf.Log10(musicSlider.value) * 50);
        Save();
    }

    public void ChangeSFXVolume()
    {
        myAudioMixer.SetFloat("sfxVolume", Mathf.Log10(sfxSlider.value) * 50);
        Save();
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }
}
