using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    AudioSource source;
    public AudioClip[] clips;
    void Start()
    {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMusic(int newSong)
    {
        source.Stop();
        source.clip = clips[newSong];
        source.Play();
    }

}
