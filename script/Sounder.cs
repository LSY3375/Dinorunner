using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounder : MonoBehaviour
{
    public enum Sfx {Jump, Land, Hit, Reset }
    public AudioClip[] clips;
    AudioSource audios;
    void Awake()
    {
        audios = GetComponent<AudioSource>();
    }

    public void PlaySound(Sfx sfx)
    {
        audios.clip = clips[(int)sfx];
        audios.Play();
    }
}
