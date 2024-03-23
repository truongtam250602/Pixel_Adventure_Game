using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("Button Audio")]
    [SerializeField] private AudioClip clickedAudio;
    [SerializeField] private AudioClip hoverAudio   ;
   
    [Header("Audio Clip Player")]
    public AudioClip background;
    public AudioClip jumpAudio;
    public AudioClip collectOrangeAudio;
    public AudioClip collectHeartAudio;
    public AudioClip trampolineAudio;
    public AudioClip startGameAudio;
    public AudioClip deathAudio;
    public AudioClip hitAudio;
    public AudioClip breakAudio;
    public AudioClip slideWallAudio;
    public AudioClip winGameAudio;
    public AudioClip cannonAudio;

    [Header("Audio Character")]
    public AudioClip[] listCharacterAudio;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        if(startGameAudio != null)
        {
            PlaySFX(startGameAudio);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public bool ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        return musicSource.mute;
    }
    public bool ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
        return SFXSource.mute;
    }
    public void VolumeMusic(float volume)
    {
        musicSource.volume = volume;
    }
    public void VolumeSFX(float volume)
    {
        SFXSource.volume = volume;
    }
}
