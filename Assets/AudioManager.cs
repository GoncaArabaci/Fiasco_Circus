using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip clownFinish;
    public AudioClip clownHorn;
    public AudioClip spectatorBoo;
    public AudioClip spectatorLaugh;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}