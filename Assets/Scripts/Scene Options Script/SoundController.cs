using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider, sfxSlider;
    [SerializeField] private Button musicBtn, sfxBtn;
    [SerializeField] private Sprite musicImg, musicMuteImg, sfxImg, sfxMuteImg;

    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void ToggleMusic()
    {
        if(AudioManager.Instance.ToggleMusic() == true)
        {
            musicBtn.GetComponent<Image>().sprite = musicMuteImg;
        }
        else
        {
            musicBtn.GetComponent<Image>().sprite = musicImg;
        }
    }
    public void ToggleSFX()
    {
        if (AudioManager.Instance.ToggleSFX() == true)
        {
            sfxBtn.GetComponent<Image>().sprite = sfxMuteImg;
        }
        else
        {
            sfxBtn.GetComponent<Image>().sprite = sfxImg;
        }
    }
    public void VolumeMusic()
    {
        AudioManager.Instance.VolumeMusic(musicSlider.value);
    }
    public void VolumeSFX()
    {
        AudioManager.Instance.VolumeSFX(sfxSlider.value);   
    }
    public void SetMusicVolume()
    {
        float volumeMusic = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volumeMusic) * 20);
        PlayerPrefs.SetFloat("musicVolume", volumeMusic);
    }
    public void SetSFXVolume()
    {
        float volumeSFX = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volumeSFX) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volumeSFX);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
    }
}
