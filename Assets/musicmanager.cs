using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource sound;
    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        sound.volume = PlayerPrefs.GetFloat("volume");
        sound.Play();
    }
}
