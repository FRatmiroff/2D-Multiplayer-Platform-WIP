using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SoundSource;

    public AudioClip jump;

    public void PlaySound(AudioClip clip)
    {
        SoundSource.PlayOneShot(clip);
    }
}
