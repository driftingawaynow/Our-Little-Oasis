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

    public void ChangeMusicVolume()
    {
        myAudioMixer.SetFloat("musicVolume", Mathf.Log10(musicSlider.value) * 50);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        myAudioMixer.SetFloat("sfxVolume", Mathf.Log10(sfxSlider.value) * 50);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }

    public void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        Debug.Log(PlayerPrefs.GetFloat("sfxVolume"));
    }
}
