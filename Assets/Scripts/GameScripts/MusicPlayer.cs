using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    private Text DisplaySong;
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
        DisplaySong = GetComponent<Text>();
    }

    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    void Update()
    {

        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            DisplaySong.text = audioSource.clip.name;
            audioSource.Play();
        }
        
        //DisplaySong.text = audioSource.clip.name;

    }

}
