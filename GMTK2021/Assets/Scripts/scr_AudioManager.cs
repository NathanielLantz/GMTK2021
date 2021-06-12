using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource soundEffectsAudioSource;
    [SerializeField]
    AudioSource musicAudioSource;

    private static scr_AudioManager instance;
    public static scr_AudioManager Instance { get
        {
            
            if(instance == null)
            {
                instance = FindObjectOfType<scr_AudioManager>();
            }
            return instance;
        }

        
    }

    private void Awake()
    {
        instance = this;
    }

    public static void PlayMusic(AudioClip audioClip, float delay = 0)
    {

        instance.PlaySoundAfterDelay(audioClip, false, delay);
    }

    public static void StopMusic(float delay = 0)
    {
        instance.StartCoroutine(instance.StopMusicAfterDelay(delay));
    } 

    public static void PlaySoundEffect(AudioClip audioClip, float delay = 0)
    {
        instance.PlaySoundAfterDelay(audioClip, true, delay);
    }

    private IEnumerator StopMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
       
        musicAudioSource.Stop();
       
    }

    private IEnumerator PlaySoundAfterDelay(AudioClip audioClip, bool isSoundEffect, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(isSoundEffect)
        {
            soundEffectsAudioSource.PlayOneShot(audioClip);
        }
        else
        {
            musicAudioSource.clip = audioClip;
            musicAudioSource.Play();
        }
    }
}
