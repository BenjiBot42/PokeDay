using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundFXManager : MonoBehaviour
{
    public static soundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audio clip         
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get length of audio clip
        float clipLength = audioSource.clip.length;

        //destroy clip after done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
