using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource BgmAudio;
    [SerializeField] AudioSource SFXAudio;

    public AudioClip Bgm;
    public AudioClip Throw;
    public AudioClip Timer;
    public AudioClip End;

    private void Start()
    {
        BgmAudio.clip = Bgm;
        BgmAudio.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXAudio.PlayOneShot(clip);
    }

}
