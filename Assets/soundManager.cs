using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sound;
    public AudioClip[] soundslist;
    public bool shouldILoop = false;
    public bool amIPlaying = false;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void PlaySound(int whichsound)
    {if (!shouldILoop)
        {
            sound.clip = soundslist[whichsound];
            sound.Play();

        }
    else
        {
            if(!sound.isPlaying) {
                sound.clip = soundslist[whichsound];
                sound.Play();
            }
            
        }
        
        if(shouldILoop)
        {
            sound.loop = true;
        }
    }

    public void letmeplay()
    {
        amIPlaying = false;
    }
}
