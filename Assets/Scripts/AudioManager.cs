using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

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

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        PlaySFX(startGameAudio);
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
}
