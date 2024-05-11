using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioSource soundAudioSource;
    public AudioSource musicAudioSource;

    [Header("Music")]
    public AudioClip homeMusic;
    public AudioClip playMusic;

    [Header("Sound")]
    public AudioClip tickSign;
    public AudioClip buttonClick;
    public AudioClip win;
    public AudioClip lose;

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        musicAudioSource.volume = 0.7f;
    }
    public void PlaySound(AudioClip sound)
    {
        soundAudioSource.PlayOneShot(sound);
    }
    public void PlayMusic(AudioClip music)
    {
        musicAudioSource.clip = music;
        musicAudioSource.Play();
    }

    public void PlayClickButtonSound()
    {
        soundAudioSource.PlayOneShot(buttonClick);
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void UpdateSoundVolume(float volume)
    {
        soundAudioSource.volume = volume;
    }
    public void UpdateMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
    }
}
